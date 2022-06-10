using ApiBank.Application.InputModels;
using ApiBank.Application.Services.Interfaces;
using ApiBank.Application.ViewModels;
using ApiBank.Controllers;
using Moq;
using Xunit;

namespace ApiBank.UnitTests.Application.Services.Implementations
{
    public class BankServiceTests
    {
        BankController _bankController;
        Mock<IBankService> _bankServiceMock;

        public BankServiceTests()
        {
            _bankServiceMock = new Mock<IBankService>();
            _bankController = new BankController(_bankServiceMock.Object);
        }

        [Fact]
        public void TestCriarConta()
        {
            CriarContaInputModel conta = new CriarContaInputModel(1234);

            var novaConta = _bankController.CriarConta(conta);
            var retorno = ((Microsoft.AspNetCore.Mvc.ObjectResult)novaConta).Value;

            Assert.Equal("Conta " + conta.NumeroConta + " criada com sucesso.", retorno);
        }

        [Fact]
        public void TestDeposito()
        {
            var conta = new CriarContaInputModel(1234);
            var deposito = new DepositoInputModel(1234, 100);

            var novaConta = _bankController.CriarConta(conta);
            var retornoConta = ((Microsoft.AspNetCore.Mvc.ObjectResult)novaConta).Value;
            Assert.Equal("Conta " + conta.NumeroConta + " criada com sucesso.", retornoConta);

            var novoDeposito = _bankController.Deposito(deposito);
            var retornoDeposito = ((Microsoft.AspNetCore.Mvc.ObjectResult)novoDeposito).Value;
            Assert.Equal("O valor " + deposito.Valor + " foi depositado com sucesso.", retornoDeposito);
        }

        [Fact]
        public void TestSaque()
        {
            var conta = new CriarContaInputModel(1234);
            var deposito = new DepositoInputModel(1234, 100);
            var saque = new SaqueViewModel(1234, 50);

            var novaConta = _bankController.CriarConta(conta);
            var retornoConta = ((Microsoft.AspNetCore.Mvc.ObjectResult)novaConta).Value;
            Assert.Equal("Conta " + conta.NumeroConta + " criada com sucesso.", retornoConta);

            var novoDeposito = _bankController.Deposito(deposito);
            var retornoDeposito = ((Microsoft.AspNetCore.Mvc.ObjectResult)novoDeposito).Value;
            Assert.Equal("O valor " + deposito.Valor + " foi depositado com sucesso.", retornoDeposito);

            var novoSaque = _bankController.Saque(saque);
            var retornoSaque = ((Microsoft.AspNetCore.Mvc.ObjectResult)novoSaque).Value;
            Assert.Equal("Saque realizado com sucesso.", retornoSaque);
        }

        [Fact]
        public void TestTranferencia()
        {
            var contaOrigem = new CriarContaInputModel(1234);
            var contaDestino = new CriarContaInputModel(2345);
            var deposito = new DepositoInputModel(1234, 100);
            var transferir = new TransferenciaInputModel(1234, 2345, 50);

            var novaContaOrigem = _bankController.CriarConta(contaOrigem);
            var retornoContaOrigem = ((Microsoft.AspNetCore.Mvc.ObjectResult)novaContaOrigem).Value;
            Assert.Equal("Conta " + contaOrigem.NumeroConta + " criada com sucesso.", retornoContaOrigem);

            var novaContaDestino = _bankController.CriarConta(contaOrigem);
            var retornoContaDestino = ((Microsoft.AspNetCore.Mvc.ObjectResult)novaContaDestino).Value;
            Assert.Equal("Conta " + contaDestino.NumeroConta + " criada com sucesso.", retornoContaDestino);

            var novoDeposito = _bankController.Deposito(deposito);
            var retornoDeposito = ((Microsoft.AspNetCore.Mvc.ObjectResult)novoDeposito).Value;
            Assert.Equal("O valor " + deposito.Valor + " foi depositado com sucesso.", retornoDeposito);

            var novaTransferencia = _bankController.Tranferir(transferir);
            var retornoTransferencia = ((Microsoft.AspNetCore.Mvc.ObjectResult)novaTransferencia).Value;
            Assert.Equal("O Valor " + transferir.Valor + " foi traferido para conta " + transferir.ContaDestino, retornoTransferencia);

        }

        [Fact]
        public void TestExtrato()
        {
            var conta = new CriarContaInputModel(1234);
            var extrato = new ExtratoViewModel(1234);

            var novaConta = _bankController.CriarConta(conta);
            var retorno = ((Microsoft.AspNetCore.Mvc.ObjectResult)novaConta).Value;
            Assert.Equal("Conta " + conta.NumeroConta + " criada com sucesso.", retorno);

            var novoExtrato = _bankController.Extrato(extrato);
            var retornoExtrato = ((Microsoft.AspNetCore.Mvc.ObjectResult)novoExtrato).Value;
            Assert.NotNull(retornoExtrato);
        }
    }
}
