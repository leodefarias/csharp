using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cp1correcao
{
    public class Produto
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("preco")]
        public decimal Preco { get; set; }

        [JsonPropertyName("quantidade")]
        public int Quantidade { get; set; }

        [JsonPropertyName("categoria")]
        public string Categoria { get; set; }
    }
}