﻿using System.Collections.Generic;
using System.Threading.Tasks;

//Obs: Voce é livre para implementar na linguagem de sua preferência, desde que respeite as funcionalidades e saídas existentes, além de aplicar os conceitos solicitados.
namespace TransacaoFinanceira
{
    class Program
    {
        static void Main(string[] args)
        {
            var transacoes = new List<Transacao>
            {
                new Transacao { CorrelationId = 1, DateTime = "09/09/2023 14:15:00", ContaOrigem = 938485762, ContaDestino = 2147483649, Valor = 150 },
                new Transacao { CorrelationId = 2, DateTime = "09/09/2023 14:15:05", ContaOrigem = 2147483649, ContaDestino = 210385733, Valor = 149 },
                new Transacao { CorrelationId = 3, DateTime = "09/09/2023 14:15:29", ContaOrigem = 347586970, ContaDestino = 238596054, Valor = 1100 },
                new Transacao { CorrelationId = 4, DateTime = "09/09/2023 14:17:00", ContaOrigem = 675869708, ContaDestino = 210385733, Valor = 5300 },
                new Transacao { CorrelationId = 5, DateTime = "09/09/2023 14:18:00", ContaOrigem = 238596054, ContaDestino = 674038564, Valor = 1489 },
                new Transacao { CorrelationId = 6, DateTime = "09/09/2023 14:18:20", ContaOrigem = 573659065, ContaDestino = 563856300, Valor = 49 },
                new Transacao { CorrelationId = 7, DateTime = "09/09/2023 14:19:00", ContaOrigem = 938485762, ContaDestino = 2147483649, Valor = 44 },
                new Transacao { CorrelationId = 8, DateTime = "09/09/2023 14:19:01", ContaOrigem = 573659065, ContaDestino = 675869708, Valor = 150 },
            };

            ExecutarTransacaoFinanceira executor = new ExecutarTransacaoFinanceira();
            Parallel.ForEach(transacoes, item =>
            {
                executor.Transferir(item);
            });

        }
    }
}
