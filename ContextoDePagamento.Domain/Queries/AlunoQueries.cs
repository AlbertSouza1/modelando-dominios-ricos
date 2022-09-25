using ContextoDePagamento.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace ContextoDePagamento.Domain.Queries
{
    public static class AlunoQueries
    {
        public static Expression<Func<Aluno, bool>> ObterInformacoesDoAluno(string documento)
        {
            return x => x.Documento.Numero == documento;
        }
    }
}
