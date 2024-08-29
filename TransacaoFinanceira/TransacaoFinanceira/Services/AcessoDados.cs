using System;
using System.Collections.Generic;
using TransacaoFinanceira.Models;

namespace TransacaoFinanceira.Services
{
    public class AcessoDados
    {
        private readonly List<ContaSaldo> TABELA_SALDOS;

        public AcessoDados()
        {
            TABELA_SALDOS = new List<ContaSaldo>
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
            return TABELA_SALDOS.Find(x => x.Conta == id);
        }

        public bool Atualizar(ContaSaldo dado)
        {
            try
            {
                TABELA_SALDOS.RemoveAll(x => x.Conta == dado.Conta);
                TABELA_SALDOS.Add(dado);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
