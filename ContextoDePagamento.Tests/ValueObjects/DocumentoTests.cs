using ContextoDePagamento.Domain.Enums;
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
    public class DocumentoTests
    {
        [TestMethod]
        [DataRow("45521234544111", true)]
        [DataRow("455212345411", false)]
        [DataRow("455212345444111", false)]
        public void Dado_um_CNPJ_deve_validar_se_possui_quatorze_numeros(string numero, bool ehValido)
        {
            var sut = new Documento(numero, TipoDocumento.CNPJ);

            Assert.AreEqual(ehValido, sut.IsValid);
        }

        [TestMethod]
        [DataRow("45521234544", true)]
        [DataRow("4552123454", false)]
        [DataRow("455212345444", false)]
        public void Se_documento_eh_CPF_deve_validar_se_possui_onze_numeros(string numero, bool ehValido)
        {
            var sut = new Documento(numero, TipoDocumento.CPF);

            Assert.AreEqual(ehValido, sut.IsValid);
        }
    }
}
