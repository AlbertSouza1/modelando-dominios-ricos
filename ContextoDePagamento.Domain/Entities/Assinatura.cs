using ContextoDePagamento.Domain.Entities.Pagamentos;
using ContextoDePagamento.Shared.Entities;
using System;
using System.Collections.Generic;

namespace ContextoDePagamento.Domain.Entities
{
    public class Assinatura : Entidade
    {
        private List<Pagamento> _pagamentos;

        public Assinatura(DateTime? dataDeValidade)
        {
            DataDeInicio = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
            DataDeValidade = dataDeValidade;
            Ativa = true;
            _pagamentos = new List<Pagamento>();           
        }

        public DateTime DataDeInicio { get; private set; }
        public DateTime DataUltimaAtualizacao { get; private set; }
        public DateTime? DataDeValidade { get; private set; }
        public bool Ativa { get; private set; }
        public IReadOnlyCollection<Pagamento> Pagamentos => _pagamentos.ToArray();

        public bool ExistePagamentoVinculado => Pagamentos.Count > 0;

        public void AdicionarPagamento(Pagamento pagamento) => _pagamentos.Add(pagamento);

        public void AlterarAtivacao(bool ativa)
        {
            Ativa = ativa;
            DataUltimaAtualizacao = DateTime.Now;
        }
    }
}
