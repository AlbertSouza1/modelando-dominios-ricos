using ContextoDePagamento.Shared.Validations;
using System;

namespace ContextoDePagamento.Shared.Entities
{
    public abstract class Entidade : Validacao
    {
        public Guid Id { get; set; }

        public Entidade()
            => Id = Guid.NewGuid();       
    }
}
