using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem
{
    internal class EmailSubscriber : ISubscriber
    {
        private readonly string _emailAddress;

        public EmailSubscriber(string emailAddress)
        {
            this._emailAddress = emailAddress;
        }

        public async Task OnNotificationReceived(Notification notification)
        {
            await Task.Delay(1000);
            Console.WriteLine($"Email sent to: {_emailAddress}: {notification.Title} - {notification.Message}");
        }
    }
}
