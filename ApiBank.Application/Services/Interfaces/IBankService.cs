using ApiBank.Application.InputModels;
using ApiBank.Application.ViewModels;
using ApiBank.Core.Entities;
using System.Collections.Generic;

namespace ApiBank.Application.Services.Interfaces
{
    public interface IBankService
    {
        bool CriarConta(CriarContaInputModel inputModel);
        bool Deposito(DepositoInputModel inputModel);
        bool Saque(SaqueViewModel viewModel);
        bool Transferencia(TransferenciaInputModel inputModel);
        List<Extrato> Extrato(ExtratoViewModel conta);
        bool ValidaConta(int conta);
    }
}
