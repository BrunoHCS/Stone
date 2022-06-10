using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBank.Core.Entities
{
    public class Extrato : BaseEntities
    {
        public Extrato()
        {

        }

        public Extrato(int numeroConta)
        {
            NumeroConta = numeroConta;
        }
        
        public int NumeroConta { get; set; }
        public double SaldoTotal { get; set; }
        public string TipoOperacao { get; set; }
        public double Valor { get; set; }
        public string Taxa { get; set; }

        public Extrato SalvaExtrato(double saldoTotal, string tipoOperacao, double valor, string taxa)
        {
            Extrato extrato = new Extrato(this.NumeroConta)
            {
                SaldoTotal = saldoTotal,
                TipoOperacao = tipoOperacao,
                Valor = valor,
                Taxa = taxa
            };       

            return extrato;
        }
    }
}
