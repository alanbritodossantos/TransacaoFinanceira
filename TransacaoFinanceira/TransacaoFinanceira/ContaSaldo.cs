namespace TransacaoFinanceira
{
    public class ContaSaldo
    {
        public ContaSaldo(uint conta, decimal valor)
        {
            this.Conta = conta;
            this.Saldo = valor;
        }
        public uint Conta { get; set; }
        public decimal Saldo { get; set; }
    }
}
