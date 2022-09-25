using ContextoDePagamento.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContextoDePagamento.Tests.Commands
{
    [TestClass]
    public class CriaAssinaturaBoletoCommandTests
    {
        [TestMethod]
        public void Deve_ser_invalido_se_UF_nao_possuir_dois_caracteres()
        {
            //Arrange
            var command = new CriaAssinaturaBoletoCommand();
            command.UF = "SÃO PAULO";

            //Act
            command.Validar();

            //Assert
            Assert.IsFalse(command.IsValid);
            Assert.AreEqual("UF deve possuir 2 caracteres.", command.ObterPrimeiraMensagem());
        }

        [TestMethod]
        public void Deve_ser_valido_se_UF_possuir_dois_caracteres()
        {
            //Arrange
            var command = new CriaAssinaturaBoletoCommand();
            command.UF = "SP";

            //Act
            command.Validar();

            //Assert
            Assert.IsTrue(command.IsValid);
        }
    }
}
