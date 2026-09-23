using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public sealed class PedidoService(AppDbContext db) : IPedidoService
    {
        public async Task<OperacaoResultado<PedidoResponse>> CriarAsync(CriarPedidoRequest request)
        {
            var erro = ValidarCriacao(request);
            if (erro is not null)
            {
                return OperacaoResultado<PedidoResponse>.Falha(StatusCodes.Status400BadRequest, erro);
            }

            var pedido = MapearEntidade(request);
            db.Pedidos.Add(pedido);
            await db.SaveChangesAsync();

            return OperacaoResultado<PedidoResponse>.Ok(Mapear(pedido), StatusCodes.Status201Created);
        }

        public async Task<IReadOnlyList<PedidoResponse>> ListarAsync()
        {
            var pedidos = await ConsultaAtivos()
                .OrderBy(pedido => pedido.Id)
                .ToListAsync();

            return pedidos.Select(Mapear).ToList();
        }

        public async Task<PedidoResponse?> ObterAsync(int id)
        {
            var pedido = await ConsultaAtivos()
                .FirstOrDefaultAsync(item => item.Id == id);

            return pedido is null ? null : Mapear(pedido);
        }

        public async Task<OperacaoResultado<PedidoResponse>> AtualizarAsync(int id, AtualizarPedidoRequest request)
        {
            var pedido = await ConsultaAtivos()
                .FirstOrDefaultAsync(item => item.Id == id);

            if (pedido is null)
            {
                return OperacaoResultado<PedidoResponse>.Falha(
                    StatusCodes.Status404NotFound,
                    "Pedido não encontrado.");
            }

            if (pedido.Status != StatusPedido.Aberto)
            {
                return OperacaoResultado<PedidoResponse>.Falha(
                    StatusCodes.Status409Conflict,
                    "Pedido fechado não pode ser alterado.");
            }

            if (request.Cliente is not null)
            {
                if (string.IsNullOrWhiteSpace(request.Cliente))
                {
                    return OperacaoResultado<PedidoResponse>.Falha(
                        StatusCodes.Status400BadRequest,
                        "Informe o cliente.");
                }

                pedido.Cliente = request.Cliente.Trim();
            }

            await db.SaveChangesAsync();
            return OperacaoResultado<PedidoResponse>.Ok(Mapear(pedido));
        }

        public async Task<OperacaoResultado> DesativarAsync(int id)
        {
            var pedido = await db.Pedidos
                .FirstOrDefaultAsync(item => item.Id == id && item.Ativo);

            if (pedido is null)
            {
                return OperacaoResultado.Falha(
                    StatusCodes.Status404NotFound,
                    "Pedido não encontrado.");
            }

            pedido.Ativo = false;
            await db.SaveChangesAsync();
            return OperacaoResultado.Ok(StatusCodes.Status204NoContent);
        }

        public async Task<OperacaoResultado<PedidoResponse>> FecharAsync(int id)
        {
            var pedido = await ConsultaAtivos()
                .FirstOrDefaultAsync(item => item.Id == id);

            if (pedido is null)
            {
                return OperacaoResultado<PedidoResponse>.Falha(
                    StatusCodes.Status404NotFound,
                    "Pedido não encontrado.");
            }

            if (pedido.Status != StatusPedido.Aberto)
            {
                return OperacaoResultado<PedidoResponse>.Falha(
                    StatusCodes.Status409Conflict,
                    "Pedido já está fechado.");
            }

            if (pedido.Itens.Count == 0)
            {
                return OperacaoResultado<PedidoResponse>.Falha(
                    StatusCodes.Status409Conflict,
                    "Pedido sem itens não pode ser fechado.");
            }

            pedido.Total = pedido.Itens.Sum(item => item.Quantidade * item.ValorUnitario);
            pedido.Status = StatusPedido.Fechado;
            await db.SaveChangesAsync();

            return OperacaoResultado<PedidoResponse>.Ok(Mapear(pedido));
        }

        public async Task<OperacaoResultado<ImportacaoResponse>> ImportarAsync(
            IReadOnlyList<CriarPedidoRequest>? pedidos)
        {
            if (pedidos is null || pedidos.Count == 0)
            {
                return OperacaoResultado<ImportacaoResponse>.Falha(
                    StatusCodes.Status400BadRequest,
                    "A lista de pedidos está vazia.");
            }

            for (var indice = 0; indice < pedidos.Count; indice++)
            {
                var erro = ValidarCriacao(pedidos[indice]);
                if (erro is not null)
                {
                    return OperacaoResultado<ImportacaoResponse>.Falha(
                        StatusCodes.Status400BadRequest,
                        $"Pedido na posição {indice + 1}: {erro}");
                }
            }

            var entidades = pedidos.Select(MapearEntidade).ToList();

            await using var transacao = await db.Database.BeginTransactionAsync();
            try
            {
                await db.Pedidos.AddRangeAsync(entidades);
                await db.SaveChangesAsync();
                await transacao.CommitAsync();
            }
            catch
            {
                await transacao.RollbackAsync();
                throw;
            }

            return OperacaoResultado<ImportacaoResponse>.Ok(new ImportacaoResponse
            {
                Quantidade = entidades.Count,
                Ids = entidades.Select(pedido => pedido.Id).ToList()
            }, StatusCodes.Status201Created);
        }

        public async Task<IReadOnlyList<ResumoStatusResponse>> ObterResumoAsync()
        {
            return await db.Pedidos
                .Where(pedido => pedido.Ativo)
                .GroupBy(pedido => pedido.Status)
                .Select(grupo => new ResumoStatusResponse
                {
                    Status = grupo.Key,
                    Quantidade = grupo.Count(),
                    ValorTotal = grupo.Sum(pedido => pedido.Total)
                })
                .OrderBy(item => item.Status)
                .ToListAsync();
        }

        private IQueryable<Pedido> ConsultaAtivos() =>
            db.Pedidos
                .Include(pedido => pedido.Itens)
                .Where(pedido => pedido.Ativo);

        private static string? ValidarCriacao(CriarPedidoRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Cliente))
            {
                return "Informe o cliente.";
            }

            if (request.Itens is null || request.Itens.Count == 0)
            {
                return "O pedido precisa ter ao menos um item.";
            }

            for (var indice = 0; indice < request.Itens.Count; indice++)
            {
                var erroItem = ValidarItem(request.Itens[indice]);
                if (erroItem is not null)
                {
                    return $"Item {indice + 1}: {erroItem}";
                }
            }

            return null;
        }

        private static string? ValidarItem(CriarItemPedidoRequest item)
        {
            if (string.IsNullOrWhiteSpace(item.Produto))
            {
                return "Informe o produto.";
            }

            if (item.Quantidade <= 0)
            {
                return "A quantidade deve ser maior que zero.";
            }

            if (item.ValorUnitario <= 0)
            {
                return "O valor unitário deve ser maior que zero.";
            }

            return null;
        }

        private static Pedido MapearEntidade(CriarPedidoRequest request) => new()
        {
            Cliente = request.Cliente.Trim(),
            Itens = request.Itens.Select(item => new ItemPedido
            {
                Produto = item.Produto.Trim(),
                Quantidade = item.Quantidade,
                ValorUnitario = item.ValorUnitario
            }).ToList()
        };

        private static PedidoResponse Mapear(Pedido pedido) => new()
        {
            Id = pedido.Id,
            Cliente = pedido.Cliente,
            Status = pedido.Status,
            Total = pedido.Total,
            Itens = pedido.Itens.Select(item => new ItemPedidoResponse
            {
                Id = item.Id,
                Produto = item.Produto,
                Quantidade = item.Quantidade,
                ValorUnitario = item.ValorUnitario
            }).ToList()
        };
    }
}
