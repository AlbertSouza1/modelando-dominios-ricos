using ContextoDePagamento.Shared.ValueObjects;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDePagamento.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco(string rua, string numero, string bairro, string cep, string cidade, string uF, string pais)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            UF = uF;
            Pais = pais;

            if (string.IsNullOrEmpty(rua))
                AddNotification(Rua, "A rua deve ser preenchida.");

            AddNotifications(new Contract<Endereco>()
                .Requires()
                .IsNotNullOrEmpty(rua, Rua, "A rua deve ser informada.")
                .IsNotNullOrEmpty(numero, Numero, "O número deve ser informado.")
                .IsNotNullOrEmpty(bairro, Bairro, "O bairro deve ser informado.")
                .IsNotNullOrEmpty(cep, CEP, "O CEP deve ser informado.")
                .IsNotNullOrEmpty(cidade, Cidade, "A cidade deve ser informada.")
                );
        }

        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public string Pais { get; private set; }

        public bool EnderecoValido() => IsValid;
    }
}
