using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBanco.API.Data;
using ProjetoBanco.API.Models;

namespace ProjetoBanco.API.Controllers
{
    [Route("api/agencias")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgenciasController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/agencias
        [HttpPost]
        public async Task<ActionResult<Agencia>> PostAgencia(Agencia agencia)
        {
            _context.Agencias.Add(agencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAgencia), new { id = agencia.IdAgencia }, agencia);
        }

        // GET: api/agencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agencia>> GetAgencia(int id)
        {
            var agencia = await _context.Agencias.FindAsync(id);

            if (agencia == null)
            {
                return NotFound();
            }

            return agencia;
        }
    }
}
