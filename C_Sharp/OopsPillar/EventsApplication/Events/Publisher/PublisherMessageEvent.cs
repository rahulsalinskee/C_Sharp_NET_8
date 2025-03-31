using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Publisher
{
    public delegate void MessageDelegate(object sender, MessageToSubscriber messageToSubscriber);

    public class PublisherMessageEvent
    {
        public static event MessageDelegate? RaiseMessageDelegateEvent;

        public void TriggerEventOnPublishMessage(string message)
        {
            Console.WriteLine("Message From Publisher...");

            if (RaiseMessageDelegateEvent is not null)
            {
                MessageToSubscriber messageToSubscriber = new(message: message);

                RaiseMessageDelegateEvent(this, messageToSubscriber);
            }
            else
            {
                Console.WriteLine("Publisher: No subscribers to notify");
            }
        }
    }
}
