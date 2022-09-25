using ContextoDePagamento.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContextoDePagamento.Tests.Validations
{
    [TestClass]
    public class ValidacaoTests
    {
        [TestMethod]
        [DataRow("Nome", "Sobrenome", "")]
        [DataRow("", "Sobrenome", "O nome deve ser preenchido.")]
        [DataRow("Nome", "", "O sobrenome deve ser preenchido.")]
        [DataRow("", "", "O nome deve ser preenchido.\r\nO sobrenome deve ser preenchido.")]
        public void Deve_unir_as_mensagens_em_string_separado_por_quebra_de_linha(string primeiroNome, string sobrenome, string mensagemEsperada)
        {
            //Arrange & Act
            var sut = new Nome(primeiroNome, sobrenome);

            //Assert
            Assert.AreEqual(mensagemEsperada, sut.MensagensEmTexto);
        }

        [TestMethod]
        [DataRow("Nome", "Sobrenome", 0)]
        [DataRow("", "Sobrenome", 1)]
        [DataRow("Nome", "", 1)]
        [DataRow("", "", 2)]
        public void Deve_unir_todas_as_mensagens_em_uma_lista(string primeiroNome, string sobrenome, int quantidadeMensagens)
        {
            //Arrange & Act
            var sut = new Nome(primeiroNome, sobrenome);

            //Assert
            Assert.AreEqual(quantidadeMensagens, sut.Mensagens.Count);
        }

        [TestMethod]
        [DataRow("Nome", "Sobrenome", "")]
        [DataRow("", "Sobrenome", "O nome deve ser preenchido.")]
        [DataRow("Nome", "", "O sobrenome deve ser preenchido.")]
        [DataRow("", "", "O nome deve ser preenchido.")]
        public void Dado_uma_lista_de_mensagens_deve_retornar_a_primeira(string primeiroNome, string sobrenome, string mensagemEsperada)
        {
            //Arrange & Act
            var sut = new Nome(primeiroNome, sobrenome);

            //Assert
            Assert.AreEqual(mensagemEsperada, sut.ObterPrimeiraMensagem());
        }
    }
}
