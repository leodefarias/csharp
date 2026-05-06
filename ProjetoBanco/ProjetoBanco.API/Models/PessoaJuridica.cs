using System.ComponentModel.DataAnnotations;

namespace ProjetoBanco.API.Models
{
    public class PessoaJuridica : Cliente
    {
        [Required]
        [StringLength(18)]
        public string CNPJ { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string RazaoSocial { get; set; } = string.Empty;
    }
}
