using ContextoDePagamento.Domain.Entities;
using ContextoDePagamento.Domain.Entities.Pagamentos;
using ContextoDePagamento.Domain.Enums;
using ContextoDePagamento.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ContextoDePagamento.Tests.Entities
{
    [TestClass]
    public class AlunoTests
    {
        private Aluno _aluno;
        private Pagamento _pagamento;
        private Assinatura _assinatura;

        public AlunoTests()
        {
            _aluno = new Aluno(new Nome("Albert", "Souza"),
                                  new Documento("22222222222", TipoDocumento.CPF),
                                  new Email("email@teste.com"));

            _pagamento = new PayPal("", DateTime.Now, DateTime.Now, 1, 1, null, "", null, null);

            _assinatura = new Assinatura(null);
            _assinatura.AdicionarPagamento(_pagamento);
        }

        [TestMethod]
        public void Nao_deve_adicionar_assinatura_se_ja_existe_assinatura_ativa()
        {
            _aluno.AdicionarAssinatura(_assinatura);

            _aluno.AdicionarAssinatura(_assinatura);

            Assert.IsFalse(_aluno.IsValid);
            Assert.AreEqual("Já existe uma assinatura ativa.", _aluno.ObterPrimeiraMensagem());
        }
       
        [TestMethod]
        public void Deve_adicionar_assinatura_se_assinatura_eh_valida_e_nao_existe_nenhuma_ativa()
        {
            _aluno.AdicionarAssinatura(_assinatura);

            Assert.IsTrue(_aluno.IsValid);
        }

        [TestMethod]
        public void Nao_deve_adicionar_assinatura_sem_pagamento_vinculado()
        {
            _aluno.AdicionarAssinatura(new Assinatura(null));

            Assert.IsFalse(_aluno.IsValid);
            Assert.AreEqual("Esta assinatura não possui pagamentos.", _aluno.ObterPrimeiraMensagem());
        }
    }
}
