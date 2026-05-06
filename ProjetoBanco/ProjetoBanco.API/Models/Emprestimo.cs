using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBanco.API.Models
{
    public class Emprestimo : Produto
    {
        [Column(TypeName = "NUMBER(18,2)")]
        public decimal ValorMinimo { get; set; }

        [Column(TypeName = "NUMBER(18,2)")]
        public decimal ValorMaximo { get; set; }

        [Column(TypeName = "NUMBER(5,2)")]
        public decimal TaxaJuros { get; set; }
    }
}
