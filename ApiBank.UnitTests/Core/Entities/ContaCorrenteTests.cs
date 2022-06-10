using ApiBank.Core.Entities;
using Xunit;

namespace ApiBank.UnitTests.Core.Entities
{
    public class ContaCorrenteTests
    {
        [Fact]
        public void TestDepositar()
        {
            var contaCorrente = new ContaCorrente(1234);
            var deposito = contaCorrente.Depositar(100);

            Assert.Equal(99, deposito);
        }

        [Fact]
        public void TestSacar()
        {
            var contaCorrente = new ContaCorrente(1234);

            var deposito = contaCorrente.Depositar(100);
            Assert.Equal(99, deposito);

            var saque = contaCorrente.Sacar(50);
            Assert.Equal(45, saque);
        }

        [Fact]
        public void TestRetornaSaldo()
        {
            var contaCorrente = new ContaCorrente(1234);
            var retornaSaldo = contaCorrente.RetornaSaldo();

            Assert.Equal(0, retornaSaldo);
        }

        [Fact]
        public void TestTransferir()
        {
            var contaCorrente = new ContaCorrente(1234);
            var deposito = contaCorrente.Depositar(100);
            Assert.Equal(99, deposito);

            var transferir = contaCorrente.Transferir(90);

            Assert.Equal(8, transferir);
        }

        [Fact]
        public void TestRecebeTransferir()
        {
            var contaCorrente = new ContaCorrente(1234);

            var recebeTransferir = contaCorrente.RecebeTransferir(100);
            Assert.Equal(100, recebeTransferir);
        }
    }
}
