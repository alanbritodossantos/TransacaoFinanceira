using System;
using TransacaoFinanceira.Models;
using TransacaoFinanceira.Repositories;

namespace TransacaoFinanceira.Services
{
    class ExecutarTransacaoFinanceira : AcessoDados
    {
        public void Transferir(Transacao transacao)
        {
            lock (this)
            {
                var contaOrigem = GetSaldo(transacao.ContaOrigem);
                if (contaOrigem == null || contaOrigem.Saldo < transacao.Valor)
                {
                    Console.WriteLine($"Transação número {transacao.CorrelationId} foi cancelada por falta de saldo ou conta inexistente.");
                }
                else
                {
                    var contaDestino = GetSaldo(transacao.ContaDestino);
                    if (contaDestino != null)
                    {
                        contaOrigem.Saldo -= transacao.Valor;
                        contaDestino.Saldo += transacao.Valor;
                        Atualizar(contaOrigem);
                        Atualizar(contaDestino);
                        Console.WriteLine($"Transação número {transacao.CorrelationId} foi efetivada com sucesso! Novos saldos: Conta Origem: {contaOrigem.Saldo} | Conta Destino: {contaDestino.Saldo}");
                    }
                    else
                    {
                        Console.WriteLine($"Transação número {transacao.CorrelationId} falhou: conta de destino não encontrada.");
                    }
                }
            }
        }
    }
}
