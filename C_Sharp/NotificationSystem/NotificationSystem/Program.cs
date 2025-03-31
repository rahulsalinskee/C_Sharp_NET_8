using NotificationSystem;

NotificationService notificationService = new();

var subscriber1 = new EmailSubscriber(emailAddress: "user1@gmail.com");
var subscriber2 = new EmailSubscriber(emailAddress: "user2@gmail.com");

var id1 = notificationService.Subscribe(subscriber1);
var id2 = notificationService.Subscribe(subscriber2);

Notification notification = new(title: "System Update", message: "New Features Have Been Deployed", type: NotificationType.Success);

await notificationService.NotifyAllAsync(notification);
await notificationService.NotifyAsync(id1, notification);

notificationService.Unsubscribe(id1);