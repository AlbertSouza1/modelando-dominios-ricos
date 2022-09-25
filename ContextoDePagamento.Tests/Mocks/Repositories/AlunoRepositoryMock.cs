using ContextoDePagamento.Domain.Entities;
using ContextoDePagamento.Domain.Repositories;
using System;

namespace ContextoDePagamento.Tests.Mocks.Repositories
{
    public class AlunoRepositoryMock : IAlunoRepository
    {
        public bool CriarAssinatura(Aluno aluno)
        {
            return true;
        }

        public bool ExisteDocumento(string documento)
        {
            if (documento == "12345678910")
                return true;

            return false;
        }

        public bool ExisteEmail(string email)
        {
            if (email == "mock@email.com")
                return true;

            return false;
        }
    }
}
