using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBank.Core.Entities
{
    public class Transferencia : BaseEntities
    {
        public Transferencia(int contaOrigem, int contaDestino, decimal valor)
        {
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
        }

        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
        public decimal Valor { get; set; }
    }
}
