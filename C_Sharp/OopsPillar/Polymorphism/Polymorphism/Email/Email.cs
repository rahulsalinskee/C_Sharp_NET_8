using Polymorphism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polymorphism.MessageType;

namespace Polymorphism.Email
{
    internal class Email
    {
        private readonly ISendMessageService? _sendMessageService;

        public Email(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }

        public void CreateEmail(string message)
        {
            _sendMessageService?.CreateMessage(message: message, MessageTypes.Email);
        }

        public void SendEmail(string email)
        {
            _sendMessageService?.SendMessage(message: email, MessageTypes.Email);
        }
    }
}
