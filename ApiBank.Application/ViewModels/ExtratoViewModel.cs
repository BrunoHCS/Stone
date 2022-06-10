using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBank.Application.ViewModels
{
    public class ExtratoViewModel
    {
        public ExtratoViewModel(int numeroConta)
        {
            NumeroConta = numeroConta;
        }

        public int NumeroConta { get; set; }
    }
}
