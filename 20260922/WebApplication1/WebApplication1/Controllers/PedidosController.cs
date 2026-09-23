using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class PedidosController(IPedidoService service) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<PedidoResponse>> Criar(CriarPedidoRequest request)
        {
            var resultado = await service.CriarAsync(request);
            if (!resultado.Sucesso)
            {
                return Falha(resultado);
            }

            return CreatedAtAction(nameof(Obter), new { id = resultado.Dados!.Id }, resultado.Dados);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PedidoResponse>>> Listar()
        {
            var pedidos = await service.ListarAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PedidoResponse>> Obter(int id)
        {
            var pedido = await service.ObterAsync(id);
            return pedido is null ? NotFound() : Ok(pedido);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<PedidoResponse>> Atualizar(int id, AtualizarPedidoRequest request)
        {
            var resultado = await service.AtualizarAsync(id, request);
            if (!resultado.Sucesso)
            {
                return Falha(resultado);
            }

            return Ok(resultado.Dados);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Desativar(int id)
        {
            var resultado = await service.DesativarAsync(id);
            if (!resultado.Sucesso)
            {
                return Falha(resultado);
            }

            return NoContent();
        }

        [HttpPost("{id:int}/fechar")]
        public async Task<ActionResult<PedidoResponse>> Fechar(int id)
        {
            var resultado = await service.FecharAsync(id);
            if (!resultado.Sucesso)
            {
                return Falha(resultado);
            }

            return Ok(resultado.Dados);
        }

        [HttpPost("importacao")]
        public async Task<ActionResult<ImportacaoResponse>> Importar(List<CriarPedidoRequest> pedidos)
        {
            var resultado = await service.ImportarAsync(pedidos);
            if (!resultado.Sucesso)
            {
                return Falha(resultado);
            }

            return StatusCode(StatusCodes.Status201Created, resultado.Dados);
        }

        [HttpGet("resumo")]
        public async Task<ActionResult<IReadOnlyList<ResumoStatusResponse>>> Resumo()
        {
            var resumo = await service.ObterResumoAsync();
            return Ok(resumo);
        }

        private ActionResult Falha(OperacaoResultado resultado) =>
            resultado.Status switch
            {
                StatusCodes.Status404NotFound => NotFound(resultado.Mensagem),
                StatusCodes.Status409Conflict => Conflict(resultado.Mensagem),
                _ => BadRequest(resultado.Mensagem)
            };
    }
}
