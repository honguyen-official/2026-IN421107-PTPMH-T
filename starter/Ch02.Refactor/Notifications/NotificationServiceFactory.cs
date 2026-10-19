namespace EduHub.Ch02.Notifications;

// Factory: tap trung viec new notifier vao 1 cho.
// Them kenh moi = them 1 case o day, khong phai sua lung tung khap noi (OCP).
public class NotificationServiceFactory : INotificationServiceFactory
{
    public INotificationService Create(NotificationChannel channel)
    {
        return channel switch
        {
            NotificationChannel.Sms => new SmsNotificationService(),
            NotificationChannel.Slack => new SlackNotificationService(),
            _ => new EmailNotificationService(),
        };
    }
}
