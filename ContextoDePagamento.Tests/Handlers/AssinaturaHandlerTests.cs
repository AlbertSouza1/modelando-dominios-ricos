using ContextoDePagamento.Domain.Commands;
using ContextoDePagamento.Domain.Handlers;
using ContextoDePagamento.Tests.Mocks.Repositories;
using ContextoDePagamento.Tests.Mocks.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDePagamento.Tests.Handlers
{
    [TestClass]
    public class AssinaturaHandlerTests
    {
        [TestMethod]
        [DataRow("12345678910", false)]
        [DataRow("11111111111", true)]
        public void Deve_ser_valiar_se_documento_ja_existe(string cpf, bool ehValido)
        {
            var mockRepository = new AlunoRepositoryMock();
            var mockEmailService = new EmailServiceMock();

            var command = new CriaAssinaturaBoletoCommand
            {
                PrimeiroNome = "a",
                Sobrenome = "a",
                Documento = cpf,
                Email = "a@email.com",
                CodigoDeBarras = "123",
                CodigoBoleto = "123",
                CodigoPagamento = "123",
                DataPagamento = DateTime.Now,
                DataDeValidade = DateTime.Now.AddDays(5),
                Total = 1,
                TotalPago = 1,
                Pagador = "123",
                DocumentoPagador = "12345678911",
                TipoDocumentoPagador = Domain.Enums.TipoDocumento.CPF,
                EmailPagador = "a@email.com",
                Rua = "asd",
                Numero = "12",
                Bairro = "Ce",
                CEP = "213",
                Cidade = "asd",
                UF = "SP",
                Pais = "A"
            };

            var handler = new AssinaturaHandler(mockRepository, mockEmailService);

            handler.Handle(command);

            Assert.AreEqual(ehValido, handler.IsValid);
        }

        [TestMethod]
        [DataRow("mock@email.com", false)]
        [DataRow("a@email.com", true)]
        public void Deve_validar_se_email_ja_existe(string email, bool ehValido)
        {
            var mockRepository = new AlunoRepositoryMock();
            var mockEmailService = new EmailServiceMock();

            var command = new CriaAssinaturaBoletoCommand
            {
                PrimeiroNome = "a",
                Sobrenome = "a",
                Documento = "66666666666",
                Email = email,
                CodigoDeBarras = "123",
                CodigoBoleto = "123",
                CodigoPagamento = "123",
                DataPagamento = DateTime.Now,
                DataDeValidade = DateTime.Now.AddDays(5),
                Total = 1,
                TotalPago = 1,
                Pagador = "123",
                DocumentoPagador = "12345678911",
                TipoDocumentoPagador = Domain.Enums.TipoDocumento.CPF,
                EmailPagador = "a@email.com",
                Rua = "asd",
                Numero = "12",
                Bairro = "Ce",
                CEP = "213",
                Cidade = "asd",
                UF = "SP",
                Pais = "A"
            };

            var handler = new AssinaturaHandler(mockRepository, mockEmailService);

            handler.Handle(command);

            Assert.AreEqual(ehValido, handler.IsValid);
        }
    }
}
