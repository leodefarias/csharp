using System.ComponentModel.DataAnnotations;

namespace ProjetoBanco.API.Models
{
    public class PessoaFisica : Cliente
    {
        [Required]
        [StringLength(14)]
        public string CPF { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }
    }
}
