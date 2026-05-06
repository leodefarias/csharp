using System.ComponentModel.DataAnnotations;

namespace ProjetoBanco.API.DTOs
{
    public class ContratacaoRequestDto
    {
        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        public decimal? ValorSolicitado { get; set; }
    }
}
