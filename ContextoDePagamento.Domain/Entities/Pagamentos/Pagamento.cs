using ContextoDePagamento.Domain.ValueObjects;
using System;

namespace ContextoDePagamento.Domain.Entities.Pagamentos
{
    public abstract class Pagamento
    {
        protected Pagamento(DateTime dataPagamento, DateTime dataDeValidade, decimal total, decimal totalPago, Endereco endereco, string pagador, Documento documento, Email email)
        {
            Codigo = Guid.NewGuid().ToString().Replace("-","").Substring(0, 10).ToUpper();
            DataPagamento = dataPagamento;
            DataDeValidade = dataDeValidade;
            Total = total;
            TotalPago = totalPago;
            Endereco = endereco;
            Pagador = pagador;
            Documento = documento;
            Email = email;
        }

        public string Codigo { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public DateTime DataDeValidade { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPago { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Pagador { get; private set; }
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }
    }
}
