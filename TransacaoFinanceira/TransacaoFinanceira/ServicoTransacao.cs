using System;

namespace TransacaoFinanceira
{
    public class ServicoTransacao
    {
        private readonly IRepositorioConta _repositorio;

        public ServicoTransacao(IRepositorioConta repositorio)
        {
            _repositorio = repositorio;
        }

        public void ExecutarTransacao(Transacao transacao)
        {
            var contaOrigem = _repositorio.GetSaldo(transacao.ContaOrigem);
            if (contaOrigem == null || contaOrigem.Saldo < transacao.Valor)
            {
                Console.WriteLine($"Transação número {transacao.CorrelationId} foi cancelada por falta de saldo ou conta inexistente.");
                return;
            }

            var contaDestino = _repositorio.GetSaldo(transacao.ContaDestino);
            if (contaDestino != null)
            {
                contaOrigem.Saldo -= transacao.Valor;
                contaDestino.Saldo += transacao.Valor;
                _repositorio.AtualizarSaldo(contaOrigem);
                _repositorio.AtualizarSaldo(contaDestino);
                Console.WriteLine($"Transação número {transacao.CorrelationId} foi efetivada com sucesso! Novos saldos: Conta Origem: {contaOrigem.Saldo} | Conta Destino: {contaDestino.Saldo}");
            }
            else
            {
                Console.WriteLine($"Transação número {transacao.CorrelationId} falhou: conta de destino não encontrada.");
            }
        }
    }
}
