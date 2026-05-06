using System.ComponentModel.DataAnnotations;

namespace ProjetoBanco.API.DTOs
{
    public class PessoaFisicaDto
    {
        [Required]
        [StringLength(150)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(14)]
        public string CPF { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }

        public int? AgenciaId { get; set; }
    }
}
