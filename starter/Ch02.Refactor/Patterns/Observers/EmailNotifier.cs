using EduHub.Ch02.Domain;
using EduHub.Ch02.Notifications;

namespace EduHub.Ch02.Patterns.Observers;

public class EmailNotifier : IEventObserver
{
    private readonly INotificationService _notifier;
    private readonly string _email;

    public EmailNotifier(INotificationService notifier, string email)
    {
        _notifier = notifier;
        _email = email;
    }

    public void OnEventCreated(Event ev)
    {
        _notifier.Send(_email, $"Su kien moi: '{ev.Title}' ({ev.Date:dd/MM/yyyy})");
    }
}
