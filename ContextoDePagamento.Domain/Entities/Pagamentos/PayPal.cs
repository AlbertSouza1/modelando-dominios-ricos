using ContextoDePagamento.Domain.ValueObjects;
using System;

namespace ContextoDePagamento.Domain.Entities.Pagamentos
{
    public class PayPal : Pagamento
    {
        public string CodigoTransacao { get; set; }

        public PayPal(string codigoTransacao,
                      DateTime dataPagamento,
                      DateTime dataDeValidade,
                      decimal total,
                      decimal totalPago,
                      Endereco endereco,
                      string pagador,
                      Documento documento,
                      Email email) : base(dataPagamento, dataDeValidade, total, totalPago, endereco, pagador, documento, email)
        {
            CodigoTransacao = codigoTransacao;
        }
    }
}
