using ContextoDePagamento.Domain.Enums;
using ContextoDePagamento.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDePagamento.Domain.Commands
{
    public class CriaAssinaturaPaypalCommand : ICommand
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get;  set; }
        public string Email { get; set; }
        public string CodigoTransacao { get; set; }
        public string CodigoPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataDeValidade { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPago { get; set; }
        public string Pagador { get; set; }
        public string DocumentoPagador { get; set; }
        public TipoDocumento TipoDocumentoPagador { get; set; }
        public string EmailPagador { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
