using ContextoDePagamento.Shared.ValueObjects;
using Flunt.Validations;

namespace ContextoDePagamento.Domain.ValueObjects
{
    public class Nome : ValueObject
    {
        public Nome(string primeiroNome, string sobrenome)
        {
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;

            AddNotifications(new Contract<Nome>()
                .Requires()
                .IsNotNullOrEmpty(PrimeiroNome, "Nome.PrimeiroNome", "O nome deve ser preenchido.")
                .IsNotNullOrEmpty(Sobrenome, "Nome.Sobrenome", "O sobrenome deve ser preenchido.")
                );
        }

        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }

        public override string ToString()
        {
            return $"{PrimeiroNome} {Sobrenome}";
        }
    }
}
