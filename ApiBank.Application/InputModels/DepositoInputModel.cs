using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBank.Application.InputModels
{
    public class DepositoInputModel
    {
        public DepositoInputModel(int numeroConta, double valor)
        {
            NumeroConta = numeroConta;
            Valor = valor;
        }

        public int NumeroConta { get; set; }
        public double Valor { get; set; }
    }
}
