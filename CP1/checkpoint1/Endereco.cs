using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace checkpoint1
{
    public class Endereco
    {
        [JsonPropertyName("cep")]
        public string Cep { get; set; }
        [JsonPropertyName("localidade")]
        public string Cidade { get; set; } = "Rio de Janeiro";
        [JsonPropertyName("bairro")]
        public string Bairro { get; set; } = "Bairro Top";
        [JsonPropertyName("uf")]
        public string Estado { get; set; } = "Rio de Janeiro";
        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; } = "Rua muito Top";
    }
}
