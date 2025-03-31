using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polymorphism.MessageType;

namespace Polymorphism.Interfaces
{
    internal interface ISendMessageService
    {
        public void CreateMessage(string message, MessageTypes messageType);

        public void SendMessage(string message, MessageTypes messageType);
    }
}
