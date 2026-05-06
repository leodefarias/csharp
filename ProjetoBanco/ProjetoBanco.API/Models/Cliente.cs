using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBanco.API.Models
{
    public abstract class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        public int? AgenciaId { get; set; }

        [ForeignKey("AgenciaId")]
        public Agencia? Agencia { get; set; }

        public string TipoCliente { get; set; } = string.Empty;
    }
}
