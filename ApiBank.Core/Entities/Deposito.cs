using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBank.Core.Entities
{
    public class Deposito : BaseEntities
    {
        public Deposito(int numeroConta, double valor)
        {
            NumeroConta = numeroConta;
            Valor = valor;
        }

        public int NumeroConta { get; set; }
        public double Valor { get; set; }
    }
}
