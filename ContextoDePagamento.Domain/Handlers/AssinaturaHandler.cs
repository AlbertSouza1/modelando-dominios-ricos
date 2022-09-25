using ContextoDePagamento.Domain.Commands;
using ContextoDePagamento.Domain.Commands.Results;
using ContextoDePagamento.Domain.Entities;
using ContextoDePagamento.Domain.Entities.Pagamentos;
using ContextoDePagamento.Domain.Repositories;
using ContextoDePagamento.Domain.Services;
using ContextoDePagamento.Domain.ValueObjects;
using ContextoDePagamento.Shared.Commands;
using ContextoDePagamento.Shared.Handlers;
using Flunt.Notifications;
using System;
using System.Linq;

namespace ContextoDePagamento.Domain.Handlers
{
    public class AssinaturaHandler : Notifiable<Notification>, IHandler<CriaAssinaturaBoletoCommand>
    {
        private readonly IAlunoRepository _repository;
        private readonly IEmailService _emailService;

        public AssinaturaHandler(IAlunoRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CriaAssinaturaBoletoCommand command)
        {
            //Fail fast validations
            command.Validar();

            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, command.Notifications.First().Message);
            }

            //Verificar se Documento já está cadastrado
            if (_repository.ExisteDocumento(command.Documento))
                AddNotification("Documento", "Este CPF já está em uso.");

            //Verificar se E-mail já está cadastrado
            if (_repository.ExisteEmail(command.Email))
                AddNotification("Email", "Este e-mail já está em uso.");

            //Gerar os VOs
            var nome = new Nome(command.PrimeiroNome, command.Sobrenome);
            var documento = new Documento(command.Documento, Enums.TipoDocumento.CPF);
            var email = new Email(command.Email);
            var endereco = new Endereco(command.Rua, command.Numero, command.Bairro, command.CEP, command.Cidade, command.UF, command.Pais);

            //Gerar as Entidades
            var aluno = new Aluno(nome, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var pagamento = new Boleto(command.CodigoDeBarras,
                                       command.CodigoBoleto,
                                       command.DataPagamento,
                                       command.DataDeValidade,
                                       command.Total,
                                       command.TotalPago,
                                       endereco,
                                       command.Pagador,
                                       documento,
                                       email);

            //Relacionamentos
            assinatura.AdicionarPagamento(pagamento);
            aluno.AdicionarAssinatura(assinatura);

            //Aplicar as validações
            AddNotifications(nome, documento, email, endereco, aluno, assinatura);

            //Checar notificações
            if (!IsValid)
                return new CommandResult(false, "Não foi possível realizar a assinatura.");

            //Salvar as informações
            _repository.CriarAssinatura(aluno);

            //Envair e-mail de boas vindas
            _emailService.Enviar(aluno.ToString(), aluno.Email.Endereco, "Bem vindo", "Sua assinatura foi criada.");

            //Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso.");
        }
    }
}
