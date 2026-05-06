using System.ComponentModel.DataAnnotations;

namespace ProjetoBanco.API.DTOs
{
    public class PessoaJuridicaDto
    {
        [Required]
        [StringLength(150)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(18)]
        public string CNPJ { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string RazaoSocial { get; set; } = string.Empty;

        public int? AgenciaId { get; set; }
    }
}
