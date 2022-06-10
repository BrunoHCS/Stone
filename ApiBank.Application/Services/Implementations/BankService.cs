using ApiBank.Application.InputModels;
using ApiBank.Application.Services.Interfaces;
using ApiBank.Application.ViewModels;
using ApiBank.Core.Entities;
using ApiBank.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace ApiBank.Application.Services.Implementations
{
    public class BankService : IBankService
    {
        private readonly ApiBankDbContext _dbContext;
        public BankService(ApiBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CriarConta(CriarContaInputModel inputModel)
        {
            var conta = _dbContext.ContaCorrente.SingleOrDefault(c => c.Conta == inputModel.NumeroConta);

            if (conta == null)
            {
                var contaCriada = new ContaCorrente(inputModel.NumeroConta);
                _dbContext.ContaCorrente.Add(contaCriada);
                _dbContext.SaveChanges();

                return true;
            }
            return false;
        }

        public bool Deposito(DepositoInputModel inputModel)
        {
            double valorDeposito = 0;
            var conta = _dbContext.ContaCorrente.SingleOrDefault(c => c.Conta == inputModel.NumeroConta);

            if (conta != null)
            {
                valorDeposito = conta.Depositar(inputModel.Valor);

                if (valorDeposito > 0)
                {
                    var deposito = new Deposito(inputModel.NumeroConta, valorDeposito);
                    _dbContext.Depositos.Add(deposito);
                    _dbContext.SaveChanges();

                    var extrato = new Extrato(inputModel.NumeroConta);
                    var salva = extrato.SalvaExtrato(conta.Saldo, "DEPOSITO", inputModel.Valor, "-1%");

                    _dbContext.Extratos.Add(salva);
                    _dbContext.SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public bool Saque(SaqueViewModel viewModel)
        {
            double valorSaque = 0;
            var conta = _dbContext.ContaCorrente.SingleOrDefault(c => c.Conta == viewModel.NumeroConta);

            if (conta != null)
            {
                valorSaque = conta.Sacar(viewModel.Valor);

                if (valorSaque > 0)
                {
                    var saque = new Saque(viewModel.NumeroConta, viewModel.Valor);
                    _dbContext.Saques.Add(saque);
                    _dbContext.SaveChanges();

                    var extrato = new Extrato(viewModel.NumeroConta);
                    var salva = extrato.SalvaExtrato(conta.Saldo, "SAQUE", viewModel.Valor, "-4");

                    _dbContext.Extratos.Add(salva);
                    _dbContext.SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public bool Transferencia(TransferenciaInputModel inputModel)
        {
            double valorTransferir = 0;
            var contaOrigem = _dbContext.ContaCorrente.SingleOrDefault(co => co.Conta == inputModel.ContaOrigem);
            var contaDestino = _dbContext.ContaCorrente.SingleOrDefault(cd => cd.Conta == inputModel.ContaDestino);

            if (contaOrigem != null && contaDestino != null)
            {
                valorTransferir = contaOrigem.Transferir(inputModel.Valor);

                if (valorTransferir > 0)
                {
                    contaDestino.RecebeTransferir(inputModel.Valor);
                    _dbContext.SaveChanges();

                    var extrato = new Extrato(inputModel.ContaOrigem);
                    var salva = extrato.SalvaExtrato(contaOrigem.Saldo, "TRANSFERENCIA", inputModel.Valor, "-1");

                    _dbContext.Extratos.Add(salva);
                    _dbContext.SaveChanges();

                    return true;
                }
                else
                    return false;
            }

            return false;
        }

        public List<Extrato> Extrato(ExtratoViewModel viewModel)
        {
            List<Extrato> listaExtratos = new List<Extrato>();

            var extratos = _dbContext.Extratos.Where(e => e.NumeroConta == viewModel.NumeroConta);

            if (extratos != null)
            {
                foreach (var item in extratos)
                {
                    Extrato extrato = new Extrato();
                    extrato.Id = item.Id;
                    extrato.NumeroConta = item.NumeroConta;
                    extrato.SaldoTotal = item.SaldoTotal;
                    extrato.TipoOperacao = item.TipoOperacao;
                    extrato.Valor = item.Valor;
                    extrato.Taxa = item.Taxa;

                    listaExtratos.Add(extrato);
                }
                return listaExtratos;
            }
            return listaExtratos;
        }

        public bool ValidaConta(int conta)
        {
            if (conta.ToString().Length < 4 || conta.ToString().Length > 4)
                return false;

            return true;
        }
    }
}
