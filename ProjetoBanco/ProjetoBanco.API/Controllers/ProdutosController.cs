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
        public async Task<ActionResult<Emprestimo>> PostEmprestimo(EmprestimoDto dto)
        {
            var emprestimo = new Emprestimo
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                ValorMinimo = dto.ValorMinimo,
                ValorMaximo = dto.ValorMaximo,
                TaxaJuros = dto.TaxaJuros
            };

            _context.Produtos.Add(emprestimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = emprestimo.IdProduto }, emprestimo);
        }

        // GET: api/produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }
    }
}
