using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLab
{
    public interface IConta
    {
        public int Numero { get; }
        public string Titular { get; }
        public decimal Saldo { get; }
        public abstract TipoConta Tipo { get; }
        public List<Movimento> Movimentos { get; }

        public List<Movimento> Movimento { get; }

        public void Depositar(decimal valor);
        public bool Sacar(decimal valor);
        protected void Creditar(string descricao, decimal valor);

    }
}
