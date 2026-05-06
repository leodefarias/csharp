using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBanco.API.Data;
using ProjetoBanco.API.DTOs;
using ProjetoBanco.API.Models;

namespace ProjetoBanco.API.Controllers
{
    [Route("api/contratacoes")]
    [ApiController]
    public class ContratacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContratacoesController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/contratacoes
        [HttpPost]
        public async Task<IActionResult> PostContratacao(ContratacaoRequestDto dto)
        {
            var cliente = await _context.Clientes.FindAsync(dto.ClienteId);
            if (cliente == null)
            {
                return NotFound(new { mensagem = "Cliente não encontrado." });
            }

            var produto = await _context.Produtos.FindAsync(dto.ProdutoId);
            if (produto == null)
            {
                return NotFound(new { mensagem = "Produto não encontrado." });
            }

            var (status, observacao) = CalcularScoreCredito(cliente);

            var contratacao = new Contratacao
            {
                ClienteId = dto.ClienteId,
                ProdutoId = dto.ProdutoId,
                DataSolicitacao = DateTime.Now,
                ValorSolicitado = dto.ValorSolicitado,
                Status = status,
                Observacao = observacao
            };

            _context.Contratacoes.Add(contratacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContratacao), new { id = contratacao.IdContratacao }, ToResponse(contratacao));
        }

        // GET: api/contratacoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContratacao(int id)
        {
            var contratacao = await _context.Contratacoes
                .FirstOrDefaultAsync(c => c.IdContratacao == id);

            if (contratacao == null)
            {
                return NotFound();
            }

            return Ok(ToResponse(contratacao));
        }

        private static object ToResponse(Contratacao c)
        {
            return new
            {
                c.IdContratacao,
                c.ClienteId,
                c.ProdutoId,
                c.DataSolicitacao,
                c.Status,
                c.ValorSolicitado,
                c.Observacao
            };
        }

        private static (string status, string observacao) CalcularScoreCredito(Cliente cliente)
        {
            string documento = cliente switch
            {
                PessoaFisica pf => pf.CPF,
                PessoaJuridica pj => pj.CNPJ,
                _ => cliente.Id.ToString()
            };

            int score = Math.Abs(documento.GetHashCode()) % 1001;

            return score switch
            {
                <= 300 => ("Reprovado", "Score de crédito insuficiente."),
                <= 600 => ("Aprovado", "Aprovado com taxa de 5% ao mês."),
                _ => ("Aprovado", "Aprovado com taxa de 3% ao mês.")
            };
        }
    }
}
