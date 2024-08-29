using TransacaoFinanceira.Models;
using TransacaoFinanceira.Repositories;
using TransacaoFinanceira.Services;
using Xunit;

namespace TransacaoFinanceira.Tests
{
    public class ExecutarTransacaoFinanceiraTests
    {
        private readonly ExecutarTransacaoFinanceira _executarTransacao;
        private readonly AcessoDados _acessoDados;

        public ExecutarTransacaoFinanceiraTests()
        {
            _acessoDados = new AcessoDados();
            _executarTransacao = new ExecutarTransacaoFinanceira();
        }

        [Fact]
        public void Transferir_DeveCancelarTransacao_SeSaldoInsuficiente()
        {            
            var transacao = new Transacao { CorrelationId = 1, ContaOrigem = 938485762, ContaDestino = 2147483649, Valor = 1000 };
            
            _executarTransacao.Transferir(transacao);
            
            var contaOrigem = _acessoDados.GetSaldo(transacao.ContaOrigem);
            Assert.Equal(180, contaOrigem.Saldo); 
        }

        [Fact]
        public void Transferir_DeveCancelarTransacao_SeContaDestinoInexistente()
        {
            
            var transacao = new Transacao { CorrelationId = 2, ContaOrigem = 938485762, ContaDestino = 999999999, Valor = 100 };
            
            _executarTransacao.Transferir(transacao);
           
            var contaOrigem = _acessoDados.GetSaldo(transacao.ContaOrigem);
            Assert.Equal(180, contaOrigem.Saldo); 
        }

        [Fact]
        public void Transferir_DeveCancelarTransacao_SeContaOrigemInexistente()
        {
            
            var transacao = new Transacao { CorrelationId = 3, ContaOrigem = 999999999, ContaDestino = 238596054, Valor = 100 };

            
            _executarTransacao.Transferir(transacao);

           
            var contaDestino = _acessoDados.GetSaldo(transacao.ContaDestino);
            Assert.Equal(478, contaDestino.Saldo); 
        }

        [Fact]
        public void Transferir_DeveCancelarTransacao_SeValorZeroOuNegativo()
        {           
            var transacao = new Transacao { CorrelationId = 4, ContaOrigem = 938485762, ContaDestino = 238596054, Valor = 0 };
            
            _executarTransacao.Transferir(transacao);
           
            var contaOrigem = _acessoDados.GetSaldo(transacao.ContaOrigem);
            var contaDestino = _acessoDados.GetSaldo(transacao.ContaDestino);
            Assert.Equal(180, contaOrigem.Saldo); 
            Assert.Equal(478, contaDestino.Saldo); 
        }

        [Fact]
        public void Transferir_DeveEfetuarTransacao_SeSaldoIgualAoValor()
        {
            
            var transacao = new Transacao { CorrelationId = 5, ContaOrigem = 675869708, ContaDestino = 238596054, Valor = 4900 };
            
            _executarTransacao.Transferir(transacao);
            
            var contaOrigem = _acessoDados.GetSaldo(transacao.ContaOrigem);
            var contaDestino = _acessoDados.GetSaldo(transacao.ContaDestino);
            Assert.Equal(0, contaOrigem.Saldo);
            Assert.Equal(5378, contaDestino.Saldo); 
        }

        [Fact]
        public void Transferir_DeveEfetuarTransacao_Simultanea()
        {           
            var transacao1 = new Transacao { CorrelationId = 6, ContaOrigem = 573659065, ContaDestino = 238596054, Valor = 50 };
            var transacao2 = new Transacao { CorrelationId = 7, ContaOrigem = 573659065, ContaDestino = 238596054, Valor = 100 };
           
            _executarTransacao.Transferir(transacao1);
            _executarTransacao.Transferir(transacao2);
            
            var contaOrigem = _acessoDados.GetSaldo(transacao1.ContaOrigem);
            var contaDestino = _acessoDados.GetSaldo(transacao1.ContaDestino);
            Assert.Equal(637, contaOrigem.Saldo); 
            Assert.Equal(628, contaDestino.Saldo);
        }
    }
}
