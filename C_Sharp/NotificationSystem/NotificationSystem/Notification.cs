using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem
{
    internal class Notification
    {
        public string Title { get; }

        public string Message { get; }

        public NotificationType Type { get; set; }

        public DateTime TimeStamp { get; set; }

        public Notification(string title, string message, NotificationType type)
        {
            Title = title;
            Message = message;
            Type = type;
            TimeStamp = DateTime.UtcNow;
        }
    }
}
