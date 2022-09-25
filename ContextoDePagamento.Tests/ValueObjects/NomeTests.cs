using ContextoDePagamento.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDePagamento.Tests.ValueObjects
{
    [TestClass]
    public class NomeTests
    {
        [DataTestMethod]
        [DataRow("Albert", "Souza", true)]
        [DataRow("", "Souza", false)]
        [DataRow("Albert", "", false)]
        [DataRow("", "", false)]
        public void Deve_validar_se_nome_possui_primeiro_nome_e_sobrenome_preenchido(string primeiroNome, string sobrenome, bool ehValido)
        {
            var sut = new Nome(primeiroNome, sobrenome);

            Assert.AreEqual(ehValido, sut.IsValid);
        }
    }
}
