using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBanco.API.Models
{
    public class Contratacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContratacao { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto? Produto { get; set; }

        public DateTime DataSolicitacao { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pendente";

        [Column(TypeName = "NUMBER(18,2)")]
        public decimal? ValorSolicitado { get; set; }

        [StringLength(500)]
        public string? Observacao { get; set; }
    }
}
