using Polymorphism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polymorphism.MessageType;

namespace Polymorphism.SMS
{
    internal class SMS
    {
        private readonly ISendMessageService _messageService;

        public SMS(ISendMessageService sendMessageService)
        {
            this._messageService = sendMessageService;
        }

        public void CreateSms(string smsMessage)
        {
            this._messageService.CreateMessage(smsMessage, MessageTypes.SMS);
        }

        public void SendEmail(string smsMessage)
        {
            this._messageService.SendMessage(smsMessage, MessageTypes.SMS);
        }
    }
}
