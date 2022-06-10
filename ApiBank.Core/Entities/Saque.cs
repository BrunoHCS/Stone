using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBank.Core.Entities
{
    public class Saque : BaseEntities
    {
        public Saque(int numeroConta, double valor)
        {
            NumeroConta = numeroConta;
            Valor = valor;
        }

        public int NumeroConta { get; set; }
        public double Valor { get; set; }
    }
}
