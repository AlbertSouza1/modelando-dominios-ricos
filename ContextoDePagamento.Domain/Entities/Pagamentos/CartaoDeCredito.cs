using ContextoDePagamento.Domain.ValueObjects;
using System;

namespace ContextoDePagamento.Domain.Entities.Pagamentos
{
    public class CartaoDeCredito : Pagamento
    {
        public CartaoDeCredito(string nomeCartao,
                               string numeroCartao,
                               string numeroUltimaTransacao,
                               DateTime dataPagamento,
                               DateTime dataDeValidade,
                               decimal total,
                               decimal totalPago,
                               Endereco endereco,
                               string pagador,
                               Documento documento,
                               Email email) : base(dataPagamento, dataDeValidade, total, totalPago, endereco, pagador, documento, email)
        {
            NomeCartao = nomeCartao;
            NumeroCartao = numeroCartao;
            NumeroUltimaTransacao = numeroUltimaTransacao;
        }

        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string NumeroUltimaTransacao { get; set; }
    }
}
