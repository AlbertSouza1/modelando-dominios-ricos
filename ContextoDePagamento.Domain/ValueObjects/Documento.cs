using ContextoDePagamento.Domain.Enums;
using ContextoDePagamento.Shared.ValueObjects;
using Flunt.Validations;

namespace ContextoDePagamento.Domain.ValueObjects
{
    public class Documento : ValueObject
    {
        public Documento(string numero, TipoDocumento tipoDocumento)
        {
            Numero = numero;
            Tipo = tipoDocumento;

            AddNotifications(new Contract<Documento>()
                .Requires()
                .IsTrue(Validar(), "Documento.Numero", "Documento inválido.")
                );
        }

        public string Numero { get; private set; }
        public TipoDocumento Tipo { get; private set; }

        private bool Validar()
        {
            if (Tipo == TipoDocumento.CNPJ && Numero.Length == 14)
                return true;

            if (Tipo == TipoDocumento.CPF && Numero.Length == 11)
                return true;

            return false;
        }
    }
}
