using System.ComponentModel.DataAnnotations;

namespace ProjetoBanco.API.DTOs
{
    public class EmprestimoDto
    {
        [Required]
        [StringLength(150)]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500)]
        public string Descricao { get; set; } = string.Empty;

        public decimal ValorMinimo { get; set; }

        public decimal ValorMaximo { get; set; }

        public decimal TaxaJuros { get; set; }
    }
}
