using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Banco.API.Models
{
    public class Agencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAgencia { get; set; }

        public string nmAgencia { get; set; }

        public string dsEndereco { get; set; }
    }
}
