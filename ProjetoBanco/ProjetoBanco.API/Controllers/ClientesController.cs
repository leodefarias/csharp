using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBanco.API.Data;
using ProjetoBanco.API.DTOs;
using ProjetoBanco.API.Models;

namespace ProjetoBanco.API.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/clientes/pf
        [HttpPost("pf")]
        public async Task<IActionResult> PostPessoaFisica(PessoaFisicaDto dto)
        {
            var clientes = await _context.Clientes.ToListAsync();
            if (clientes.OfType<PessoaFisica>().Any(c => c.CPF == dto.CPF))
            {
                return Conflict(new { mensagem = "Já existe um cliente cadastrado com este CPF." });
            }

            if (dto.AgenciaId.HasValue)
            {
                var agencia = await _context.Agencias.FindAsync(dto.AgenciaId.Value);
                if (agencia == null)
                {
                    return NotFound(new { mensagem = "Agência não encontrada." });
                }
            }

            var pf = new PessoaFisica
            {
                Nome = dto.Nome,
                Email = dto.Email,
                CPF = dto.CPF,
                DataNascimento = dto.DataNascimento,
                AgenciaId = dto.AgenciaId,
                TipoCliente = "PF"
            };

            _context.Clientes.Add(pf);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = pf.Id }, ToResponse(pf));
        }

        // POST: api/clientes/pj
        [HttpPost("pj")]
        public async Task<IActionResult> PostPessoaJuridica(PessoaJuridicaDto dto)
        {
            var clientes = await _context.Clientes.ToListAsync();
            if (clientes.OfType<PessoaJuridica>().Any(c => c.CNPJ == dto.CNPJ))
            {
                return Conflict(new { mensagem = "Já existe um cliente cadastrado com este CNPJ." });
            }

            if (dto.AgenciaId.HasValue)
            {
                var agencia = await _context.Agencias.FindAsync(dto.AgenciaId.Value);
                if (agencia == null)
                {
                    return NotFound(new { mensagem = "Agência não encontrada." });
                }
            }

            var pj = new PessoaJuridica
            {
                Nome = dto.Nome,
                Email = dto.Email,
                CNPJ = dto.CNPJ,
                RazaoSocial = dto.RazaoSocial,
                AgenciaId = dto.AgenciaId,
                TipoCliente = "PJ"
            };

            _context.Clientes.Add(pj);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = pj.Id }, ToResponse(pj));
        }

        // GET: api/clientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Agencia)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(ToResponse(cliente));
        }

        private static object ToResponse(Cliente cliente)
        {
            return cliente switch
            {
                PessoaFisica pf => new
                {
                    pf.Id,
                    pf.Nome,
                    pf.Email,
                    pf.CPF,
                    pf.DataNascimento,
                    pf.AgenciaId,
                    Agencia = pf.Agencia,
                    TipoCliente = "PF"
                },
                PessoaJuridica pj => new
                {
                    pj.Id,
                    pj.Nome,
                    pj.Email,
                    pj.CNPJ,
                    pj.RazaoSocial,
                    pj.AgenciaId,
                    Agencia = pj.Agencia,
                    TipoCliente = "PJ"
                },
                _ => cliente
            };
        }
    }
}
