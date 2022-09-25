using ContextoDePagamento.Domain.Entities;
using ContextoDePagamento.Domain.Queries;
using ContextoDePagamento.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ContextoDePagamento.Tests.Queries
{
    [TestClass]
    public class AlunoQueriesTests
    {
        private readonly IList<Aluno> _alunos;

        public AlunoQueriesTests()
        {
            _alunos = new List<Aluno>();

            for (int i = 0; i <= 10; i++)
            {
                _alunos.Add(new Aluno(new Nome("Aluno", i.ToString()),
                                      new Documento("11111111111", Domain.Enums.TipoDocumento.CPF),
                                      new Email(i.ToString()+"aluno@email.com")));                  
            }
        }

        [TestMethod]
        public void Deve_retornar_nulo_se_documento_nao_encontrado()
        {
            var expressao = AlunoQueries.ObterInformacoesDoAluno("12345678911");
            var aluno = _alunos.AsQueryable().Where(expressao).FirstOrDefault();

            Assert.AreEqual(null, aluno);
        }

        [TestMethod]
        public void Deve_retornar_o_aluno_quando_o_documento_existe()
        {
            var expressao = AlunoQueries.ObterInformacoesDoAluno("11111111111");
            var aluno = _alunos.AsQueryable().Where(expressao).FirstOrDefault();

            Assert.AreNotEqual(null, aluno);
        }
    }
}
