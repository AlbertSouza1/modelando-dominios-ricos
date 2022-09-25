using ContextoDePagamento.Domain.Entities;

namespace ContextoDePagamento.Domain.Repositories
{
    public interface IAlunoRepository
    {
        bool ExisteDocumento(string documento);
        bool ExisteEmail(string email);
        bool CriarAssinatura(Aluno aluno);
    }
}