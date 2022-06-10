using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBank.Core.Entities
{
    public class ContaCorrente : BaseEntities
    {
        public ContaCorrente(int conta)
        {
            Conta = conta;
        }

        public int Conta { get; private set; }
        public double Saldo { get; private set; }

        public double Depositar(double valor)
        {
            if (valor > 0)
            {
                valor = valor - (valor * 0.01);
                Saldo = Saldo + valor;

                return valor;
            }

            return 0;
        }

        public double Sacar(double valor)
        {
            if (Saldo > 0)
            {
                Saldo = Saldo - valor - 4;
                return Saldo;
            }

            return -1;
        }

        public double RetornaSaldo()
        {
            return Saldo;
        }

        public double Transferir(double valor)
        {
            if (Saldo > 0)
            {
                Saldo = Saldo - valor -1;
                return Saldo;
            }

            return 0;
        }

        public double RecebeTransferir(double valor)
        {
            if (valor > 0)
            {
                Saldo = Saldo + valor;

                return valor;
            }

            return 0;
        }
    }
}
