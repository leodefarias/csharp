using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fiap.Usuarios
{
    public class Aluno
    {
        [JsonPropertyName("Id")]
        public string RM { get; set; }

        [JsonPropertyName("Nome")]
        public string Nome { get; set; }

        [JsonPropertyName("Cep")]
        public string Cep { get; set; }

        [JsonPropertyName("Logradouro")]
        public string Logradouro { get; }

        [JsonPropertyName("Bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("Estado")]
        public string Estado { get; set; }

    }
}
