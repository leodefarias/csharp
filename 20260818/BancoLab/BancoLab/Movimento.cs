using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLab
{
    public class Movimento
    {
        public DateTimeOffset Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public Movimento(string descricao, decimal valor)
        {
            Descricao = descricao;
            Valor = valor;
            Data = DateTimeOffset.Now;
        }
    }
}
