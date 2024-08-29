using TransacaoFinanceira.Interfaces;
using TransacaoFinanceira.Models;
using TransacaoFinanceira.Repositories;
using TransacaoFinanceira.Services;
using Xunit;

namespace TransacaoFinanceira.Tests
{
    public class ServicoTransacaoTests
    {
        private readonly IRepositorioConta _repositorioMock;
        private readonly ServicoTransacao _servicoTransacao;

        public ServicoTransacaoTests()
        {
            _repositorioMock = new RepositorioConta();
            _servicoTransacao = new ServicoTransacao(_repositorioMock);
        }

        [Fact]
        public void ExecutarTransacao_DeveCancelarTransacao_SeSaldoInsuficiente()
        {
            var transacao = new Transacao { CorrelationId = 1, ContaOrigem = 938485762, ContaDestino = 2147483649, Valor = 1000 };
            _servicoTransacao.ExecutarTransacao(transacao);

            var contaOrigem = _repositorioMock.GetSaldo(transacao.ContaOrigem);
            Assert.Equal(180, contaOrigem.Saldo);
        }

        [Fact]
        public void ExecutarTransacao_DeveEfetivarTransacao_SeSaldoSuficiente()
        {
            var transacao = new Transacao { CorrelationId = 2, ContaOrigem = 938485762, ContaDestino = 2147483649, Valor = 150 };
            _servicoTransacao.ExecutarTransacao(transacao);

            var contaOrigem = _repositorioMock.GetSaldo(transacao.ContaOrigem);
            var contaDestino = _repositorioMock.GetSaldo(transacao.ContaDestino);
            Assert.Equal(30, contaOrigem.Saldo);
            Assert.Equal(150, contaDestino.Saldo);
        }
    }

}
