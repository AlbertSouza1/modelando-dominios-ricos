namespace ContextoDePagamento.Domain.Services
{
    public interface IEmailService
    {
        void Enviar(string destinatario, string email, string assunto, string mensagem);
    }
}
