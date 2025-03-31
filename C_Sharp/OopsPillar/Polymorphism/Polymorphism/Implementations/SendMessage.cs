using Polymorphism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polymorphism.MessageType;

namespace Polymorphism.Implementations
{
    internal class SendMessage : ISendMessageService
    {
        void ISendMessageService.CreateMessage(string message, MessageTypes messageType)
        {
            Console.WriteLine($"{messageType} - {message} is created and ready to be send!");
        }

        void ISendMessageService.SendMessage(string message, MessageTypes messageType)
        {
            Console.WriteLine($"{messageType} - {message} is send message!");
        }
    }
}
