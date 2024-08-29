using System.Collections.Generic;
using System.Linq;

namespace TransacaoFinanceira
{
    public class RepositorioConta : IRepositorioConta
    {
        private List<ContaSaldo> tabelaSaldos;

        public RepositorioConta()
        {
            tabelaSaldos = new List<ContaSaldo>
            {
                new ContaSaldo(938485762, 180),
                new ContaSaldo(347586970, 1200),
                new ContaSaldo(2147483649, 0),
                new ContaSaldo(675869708, 4900),
                new ContaSaldo(238596054, 478),
                new ContaSaldo(573659065, 787),
                new ContaSaldo(210385733, 10),
                new ContaSaldo(674038564, 400),
                new ContaSaldo(563856300, 1200)
            };
        }

        public ContaSaldo GetSaldo(uint id)
        {
            return tabelaSaldos.FirstOrDefault(x => x.Conta == id);
        }

        public void AtualizarSaldo(ContaSaldo conta)
        {
            var contaExistente = GetSaldo(conta.Conta);
            if (contaExistente != null)
            {
                contaExistente.Saldo = conta.Saldo;
            }
        }
    }

}
