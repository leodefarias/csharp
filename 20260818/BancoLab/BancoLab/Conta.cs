using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BancoLab
{
    public abstract class Conta : IConta
    {
        public int Numero { get; }
        public string Titular { get; }
        public decimal Saldo { get; private set; }
        public abstract TipoConta Tipo { get; }
        public List<Movimento> Movimentos { get; } = new List<Movimento>();

        public Conta(int numero, string titular)
        {
            if (numero <= 0)
            {
                throw new ArgumentException(nameof(numero), "numero precisa ser maior que 0");
            }

            if (string.IsNullOrWhiteSpace(titular))
            {
                throw new ArgumentException(nameof(titular), "titular precisa ser preenchido");
            }

            Numero = numero;
            Titular = titular;
            Saldo = 0;
            Movimentos = new List<Movimento>();
        }

        public abstract void Depositar(decimal valor);
        public abstract bool Sacar(decimal valor);

        protected abstract decimal ObterSaldoDisponivel();
        protected void Creditar(decimal valor, string descricao)
        {
            if (!string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException(nameof(descricao), "descricao precisa ser preenchido");
            }

            if (valor <= 0)
            {
                throw new ArgumentException(nameof(valor), "valor precisa ser maior que 0");
            }

            Saldo += valor;
            Movimento movimento = new Movimento(descricao, valor);

            Movimentos.Add(movimento);
        }
    }
}
