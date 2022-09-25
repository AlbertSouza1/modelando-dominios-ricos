using ContextoDePagamento.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDePagamento.Tests.Mocks.Services
{
    public class EmailServiceMock : IEmailService
    {
        public void Enviar(string destinatario, string email, string assunto, string mensagem)
        {
            
        }
    }
}
