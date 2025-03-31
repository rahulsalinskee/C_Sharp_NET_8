using Polymorphism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Implementations
{
    class SendLetterMessage : ISendMessageService
    {
        public void CreateMessage(string message, MessageType.MessageTypes messageType)
        {
            Console.WriteLine($"{messageType} - {message} is created and ready to be send!");
        }

        public void SendMessage(string message, MessageType.MessageTypes messageType)
        {
            Console.WriteLine($"{messageType} - {message} is send message!");
        }
    }
}
