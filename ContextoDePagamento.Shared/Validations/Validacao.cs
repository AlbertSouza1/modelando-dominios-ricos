using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContextoDePagamento.Shared.Validations
{
    public abstract class Validacao : Notifiable<Notification>
    {
        public List<string> Mensagens => Notifications.Select(x => x.Message).ToList();
        public string MensagensEmTexto => string.Join(Environment.NewLine, Notifications.Select(x => x.Message).ToList());

        public string ObterPrimeiraMensagem()
        {
            if (Mensagens.Count == 0)
                return "";

            return Mensagens.First();
        }
    }
}
