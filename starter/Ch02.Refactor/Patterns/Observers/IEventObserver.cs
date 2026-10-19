using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Patterns.Observers;

// Observer: ai quan tam su kien thi implement interface nay
// va dang ky voi EventService.
public interface IEventObserver
{
    void OnEventCreated(Event ev);
}
