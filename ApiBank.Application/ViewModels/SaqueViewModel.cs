using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBank.Application.ViewModels
{
    public class SaqueViewModel
    {
        public SaqueViewModel(int numeroConta, double valor)
        {
            NumeroConta = numeroConta;
            Valor = valor;
        }

        public int NumeroConta { get; set; }
        public double Valor { get; set; }
    }
}
