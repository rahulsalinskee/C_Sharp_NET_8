using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Publisher
{
    public class PublisherMessageEventHandler
    {
        internal static void MessagePublishLauncher()
        {
            PublisherMessageEvent publisherMessageEvent = new();
            SubscribedToPublishMessage();
            publisherMessageEvent.TriggerEventOnPublishMessage(message: "This is a test message send to the subscriber!");
        }

        private static void SubscribedToPublishMessage()
        {
            UnsubscribedToPublishMessage();
            PublisherMessageEvent.RaiseMessageDelegateEvent += PublishMessageEvent_PublishMessage;
            UnsubscribedToPublishMessage();
        }

        private static void UnsubscribedToPublishMessage()
        {
            PublisherMessageEvent.RaiseMessageDelegateEvent -= PublishMessageEvent_PublishMessage;
        }

        private static void PublishMessageEvent_PublishMessage(object sender, MessageToSubscriber messageToSubscriber)
        {
            Console.WriteLine($"Message: {messageToSubscriber.Message} : {messageToSubscriber.TimeStamp}");
        }
    }
}
