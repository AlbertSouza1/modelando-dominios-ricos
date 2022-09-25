using ContextoDePagamento.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDePagamento.Domain.Commands.Results
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {
        }

        public CommandResult(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}
