using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBank.Application.InputModels
{
    public class TransferenciaInputModel
    {
        public TransferenciaInputModel(int contaOrigem, int contaDestino, double valor)
        {
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
        }

        public int ContaOrigem { get; set; }        
        public int ContaDestino { get; set; }
        public double Valor { get; set; }
    }
}
