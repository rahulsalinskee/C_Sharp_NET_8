using Events.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Subscribers
{
    public class SubscriberOne
    {
        public SubscriberOne()
        {
            PublisherMessageEvent.RaiseMessageDelegateEvent += PublisherMessageEvent_RaiseMessageDelegateEvent;
        }

        private void PublisherMessageEvent_RaiseMessageDelegateEvent(object sender, MessageToSubscriber messageToSubscriber)
        {
            Console.WriteLine("Subscriber has received: {0} From its Publisher at {1}", messageToSubscriber.Message, messageToSubscriber.TimeStamp);
        }
    }
}
