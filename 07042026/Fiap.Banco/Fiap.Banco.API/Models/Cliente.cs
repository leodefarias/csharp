using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Banco.API.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        [ForeignKey("BancoId")]
        public Banco? Banco { get; set; }
    }
}
