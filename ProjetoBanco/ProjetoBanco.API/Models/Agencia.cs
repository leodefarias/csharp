using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBanco.API.Models
{
    public class Agencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgencia { get; set; }

        [Required]
        [StringLength(150)]
        public string NomeAgencia { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; } = string.Empty;

        [StringLength(10)]
        public string Numero { get; set; } = string.Empty;

        [StringLength(100)]
        public string Cidade { get; set; } = string.Empty;

        [StringLength(2)]
        public string Estado { get; set; } = string.Empty;
    }
}
