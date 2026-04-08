using System.ComponentModel.DataAnnotations;

namespace Fiap.Banco.API.Models
{
    public class Banco
    {

        [Key]
        public int IdBanco { get; set; }
        public string NomeBanco { get; set; }
        public DateTime DtCriacao { get; set; }
        public ICollection<Cliente>? Clientes { get; set; }
    }
}
