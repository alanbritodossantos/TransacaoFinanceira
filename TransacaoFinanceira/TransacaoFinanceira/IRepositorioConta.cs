
namespace TransacaoFinanceira
{
    public interface IRepositorioConta
    {
        ContaSaldo GetSaldo(uint id);
        void AtualizarSaldo(ContaSaldo conta);
    }
}
