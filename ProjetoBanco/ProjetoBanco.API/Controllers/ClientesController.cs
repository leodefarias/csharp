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
        public async Task<ActionResult<PessoaFisica>> PostPessoaFisica(PessoaFisicaDto dto)
        {
            var cpfExistente = await _context.Clientes
                .OfType<PessoaFisica>()
                .CountAsync(c => c.CPF == dto.CPF) > 0;

            if (cpfExistente)
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
                AgenciaId = dto.AgenciaId
            };

            _context.Clientes.Add(pf);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = pf.Id }, pf);
        }

        // POST: api/clientes/pj
        [HttpPost("pj")]
        public async Task<ActionResult<PessoaJuridica>> PostPessoaJuridica(PessoaJuridicaDto dto)
        {
            var cnpjExistente = await _context.Clientes
                .OfType<PessoaJuridica>()
                .CountAsync(c => c.CNPJ == dto.CNPJ) > 0;

            if (cnpjExistente)
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
                AgenciaId = dto.AgenciaId
            };

            _context.Clientes.Add(pj);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = pj.Id }, pj);
        }

        // GET: api/clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Agencia)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }
    }
}
