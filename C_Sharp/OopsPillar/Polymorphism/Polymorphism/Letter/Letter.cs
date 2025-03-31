using Polymorphism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polymorphism.MessageType;

namespace Polymorphism.Letter
{
    class Letter
    {
        private readonly ISendMessageService _sendMessageService;

        public Letter(ISendMessageService sendMessageService)
        {
            this._sendMessageService = sendMessageService;
        }

        public void CreateLetter(string smsMessage)
        {
            this._sendMessageService.CreateMessage(smsMessage, MessageTypes.Letter);
        }

        public void SendLetter(string smsMessage)
        {
            this._sendMessageService.SendMessage(smsMessage, MessageTypes.Letter);
        }
    }
}
