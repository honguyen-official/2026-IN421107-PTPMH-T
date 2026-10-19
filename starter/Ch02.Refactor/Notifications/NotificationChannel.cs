namespace EduHub.Ch02.Notifications;

// Factory se dung enum nay de quyet dinh tao notifier nao (OCP:
// them kenh moi chi can them enum + class, khong sua code cu).
public enum NotificationChannel
{
    Email,
    Sms,
    Slack
}
