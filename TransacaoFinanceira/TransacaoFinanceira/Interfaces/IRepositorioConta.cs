using TransacaoFinanceira.Models;

namespace TransacaoFinanceira.Interfaces
{
    public interface IRepositorioConta
    {
        ContaSaldo GetSaldo(uint id);
        void AtualizarSaldo(ContaSaldo conta);
    }
}
