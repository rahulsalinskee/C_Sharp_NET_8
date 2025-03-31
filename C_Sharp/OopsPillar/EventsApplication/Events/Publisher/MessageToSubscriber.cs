using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Publisher
{
    public class MessageToSubscriber
    {
        public string Message { get; private set; } = string.Empty;

        public DateTime TimeStamp { get; private set; }

        public MessageToSubscriber(string message)
        {
            Message = message;
            TimeStamp = DateTime.Now;
        }
    }
}
