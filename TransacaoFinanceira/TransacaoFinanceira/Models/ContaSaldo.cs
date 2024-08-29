namespace TransacaoFinanceira.Models
{
    public class ContaSaldo
    {
        public ContaSaldo(uint conta, decimal valor)
        {
            Conta = conta;
            Saldo = valor;
        }
        public uint Conta { get; set; }
        public decimal Saldo { get; set; }
    }
}
