using ContextoDePagamento.Shared.ValueObjects;
using Flunt.Validations;

namespace ContextoDePagamento.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Endereco { get; set; }

        public Email(string endereco)
        {
            Endereco = endereco;

            AddNotifications(new Contract<Email>()
                .Requires()
                .IsEmail(endereco, "Email.Endereco", "E-mail inválido.")
            );
        }
    }
}
