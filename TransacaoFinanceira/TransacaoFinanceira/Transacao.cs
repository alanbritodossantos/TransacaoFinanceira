namespace TransacaoFinanceira
{
    public class Transacao
    {
        public int CorrelationId { get; set; }
        public string DateTime { get; set; }
        public uint ContaOrigem { get; set; }
        public uint ContaDestino { get; set; }
        public decimal Valor { get; set; }
    }
}
