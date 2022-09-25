using ContextoDePagamento.Domain.ValueObjects;
using ContextoDePagamento.Shared.Entities;
using Flunt.Validations;
using System.Collections.Generic;

namespace ContextoDePagamento.Domain.Entities
{
    public class Aluno : Entidade
    {
        private List<Assinatura> _assinaturas;
        public Aluno(Nome nome, Documento documento, Email email)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
            _assinaturas = new List<Assinatura>();

            AddNotifications(nome, documento, email);
        }

        public Nome Nome { get; private set; }
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public IReadOnlyCollection<Assinatura> Assinaturas => _assinaturas.ToArray();

        public void AdicionarAssinatura(Assinatura assinatura)
        {           
            var possuiAssinaturaAtiva = ValidarSeExisteAssinaturaAtiva();

            AddNotifications(new Contract<Aluno>()
                .Requires()
                .IsFalse(possuiAssinaturaAtiva, "Aluno.Assinaturas", "Já existe uma assinatura ativa.")
                .IsTrue(assinatura.ExistePagamentoVinculado, "Aluno.Assinaturas.Pagamentos", "Esta assinatura não possui pagamentos.")
                );

            if (IsValid)
                _assinaturas.Add(assinatura);
        }

        private bool ValidarSeExisteAssinaturaAtiva()
        {
            foreach (var assinatura in _assinaturas)
                if (assinatura.Ativa) return true;

            return false;
        }

        //public void AdicionarAssinatura(Assinatura assinatura)
        //{
        //    //se ja tiver assinatura ativa, cancela

        //    //cancela todas as outras assinaturas e coloca esta como principal
        //    foreach (var item in Assinaturas)
        //        item.AlterarAtivacao(ativa: false);

        //    _assinaturas.Add(assinatura);
        //}
    }
}
