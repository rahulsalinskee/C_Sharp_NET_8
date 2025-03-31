using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem
{
    internal class NotificationService
    {
        private readonly ConcurrentDictionary<Guid, ISubscriber> _subscribers;

        public NotificationService()
        {
            this._subscribers = new ConcurrentDictionary<Guid, ISubscriber>();
        }

        public Guid Subscribe(ISubscriber subscriber)
        {
            var id = Guid.NewGuid();

            if (!_subscribers.TryAdd(key: id, value: subscriber))
            {
                throw new InvalidOperationException("Failed To Add Subscriber!");
            }

            return id;
        }

        public bool Unsubscribe(Guid subscribedId)
        {
            return _subscribers.TryRemove(subscribedId, out var subscriber);
        }

        public async Task NotifyAllAsync(Notification notification)
        {
            var notificationTasks = _subscribers.Values.Select(subscriber => NotifySubscriberSafelyAsync(subscriber, notification));
            await Task.WhenAll(notificationTasks);
        }

        public async Task NotifyAsync(Guid subscriberId, Notification notification)
        {
            if (_subscribers.TryGetValue(subscriberId, out var subscriber))
            {
                await NotifySubscriberSafelyAsync(subscriber: subscriber, notification: notification);
            }
        }

        public async Task NotifySubscriberSafelyAsync(ISubscriber subscriber, Notification notification)
        {
            try
            {
                await subscriber.OnNotificationReceived(notification);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error Notifying Subscriber: {exception.Message}");
            }
        }
    }
}
