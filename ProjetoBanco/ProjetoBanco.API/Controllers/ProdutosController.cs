using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBanco.API.Data;
using ProjetoBanco.API.DTOs;
using ProjetoBanco.API.Models;

namespace ProjetoBanco.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/produtos/emprestimo
        [HttpPost("emprestimo")]
        public async Task<IActionResult> PostEmprestimo(EmprestimoDto dto)
        {
            var emprestimo = new Emprestimo
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                ValorMinimo = dto.ValorMinimo,
                ValorMaximo = dto.ValorMaximo,
                TaxaJuros = dto.TaxaJuros,
                TipoProduto = "Emprestimo"
            };

            _context.Produtos.Add(emprestimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = emprestimo.IdProduto }, ToResponse(emprestimo));
        }

        // GET: api/produtos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(ToResponse(produto));
        }

        private static object ToResponse(Produto produto)
        {
            return produto switch
            {
                Emprestimo e => new
                {
                    e.IdProduto,
                    e.Nome,
                    e.Descricao,
                    e.ValorMinimo,
                    e.ValorMaximo,
                    e.TaxaJuros,
                    TipoProduto = "Emprestimo"
                },
                _ => produto
            };
        }
    }
}
