using ApiBank.Application.InputModels;
using ApiBank.Application.Services.Interfaces;
using ApiBank.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "API de Conta Bancária" };
        }

        [HttpPost, Route("criarconta")]
        public IActionResult CriarConta([FromBody] CriarContaInputModel inputModel)
        {
            var validaConta = _bankService.ValidaConta(inputModel.NumeroConta);

            if (!validaConta)
                return BadRequest("Erro ao criar conta, a conta de ter 4 digítos.");

            var novaconta = _bankService.CriarConta(inputModel);

            if (novaconta)
                return Ok("Conta " + inputModel.NumeroConta + " criada com sucesso.");

            return BadRequest("Erro ao criar conta ou conta já cadastrada.");
        }

        [HttpPost, Route("deposito")]
        public IActionResult Deposito([FromBody] DepositoInputModel inputModel)
        {
            var validaConta = _bankService.ValidaConta(inputModel.NumeroConta);

            if (!validaConta)
                return BadRequest("Erro, a conta de ter 4 digítos.");

            if (inputModel.Valor < 0)
                return BadRequest("Erro, o valor tem que ser maior que 0(zero).");

            var deposito = _bankService.Deposito(inputModel);

            if (deposito)
                return Ok("O valor " + inputModel.Valor + " foi depositado com sucesso.");


            return BadRequest("Erro ao depositar.");
        }

        [HttpGet, Route("saque")]
        public IActionResult Saque([FromBody] SaqueViewModel viewModel)
        {
            var validaConta = _bankService.ValidaConta(viewModel.NumeroConta);

            if (!validaConta)
                return BadRequest("Erro, a conta de ter 4 digítos.");

            if (viewModel.Valor < 0)
                return BadRequest("Erro, o valor tem que ser maior que 0(zero).");

            var saque = _bankService.Saque(viewModel);

            if (saque)
                return Ok("Saque realizado com sucesso.");

            return BadRequest("Erro ao realizar saque.");
        }

        [HttpPut, Route("transferir")]
        public IActionResult Tranferir([FromBody] TransferenciaInputModel inputModel)
        {
            var validaContaOrigem = _bankService.ValidaConta(inputModel.ContaOrigem);
            var validaContaDestino = _bankService.ValidaConta(inputModel.ContaDestino);

            if (!validaContaOrigem || !validaContaDestino)
                return BadRequest("Erro, a conta de ter 4 digítos.");

            if (inputModel.Valor < 0)
                return BadRequest("Erro, o valor tem que ser maior que 0(zero).");

            var tranferir = _bankService.Transferencia(inputModel);

            if (tranferir)
                return Ok("O Valor " + inputModel.Valor + " foi traferido para conta " + inputModel.ContaDestino);

            return BadRequest("Erro ao realizar transferência.");
        }

        [HttpGet, Route("extrato")]
        public IActionResult Extrato([FromBody] ExtratoViewModel viewModel)
        {
            var validaConta = _bankService.ValidaConta(viewModel.NumeroConta);

            if (!validaConta)
                return BadRequest("Erro, a conta de ter 4 digítos.");

            var extrato = _bankService.Extrato(viewModel);
            return Ok(extrato);
        }
    }
}
