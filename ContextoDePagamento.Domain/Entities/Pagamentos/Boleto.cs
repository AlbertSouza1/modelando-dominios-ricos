using ContextoDePagamento.Domain.ValueObjects;
using System;

namespace ContextoDePagamento.Domain.Entities.Pagamentos
{
    public class Boleto : Pagamento
    {
        public Boleto(string codigoDeBarras,
                      string codigoBoleto,
                      DateTime dataPagamento,
                      DateTime dataDeValidade,
                      decimal total,
                      decimal totalPago,
                      Endereco endereco,
                      string pagador,
                      Documento documento,
                      Email email) : base(dataPagamento, dataDeValidade, total, totalPago, endereco, pagador, documento, email)
        {
            CodigoDeBarras = codigoDeBarras;
            CodigoBoleto = codigoBoleto;
        }

        public string CodigoDeBarras { get; set; }
        public string CodigoBoleto { get; set; }
    }
}
