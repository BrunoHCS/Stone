using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBank.Application.InputModels
{
    public class CriarContaInputModel
    {
        public CriarContaInputModel(int numeroConta)
        {
            NumeroConta = numeroConta;
        }

        public int NumeroConta { get; set; }
    }
}
