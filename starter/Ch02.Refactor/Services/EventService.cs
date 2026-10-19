using EduHub.Ch02.Domain;
using EduHub.Ch02.Logging;
using EduHub.Ch02.Patterns.Observers;
using EduHub.Ch02.Repositories;

namespace EduHub.Ch02.Services;

public class EventService
{
    private readonly IClubRepository _clubs;
    private readonly IEventRepository _events;
    private readonly IAppLogger _logger;
    private readonly List<IEventObserver> _observers = new();

    public EventService(IClubRepository clubs, IEventRepository events, IAppLogger logger)
    {
        _clubs = clubs;
        _events = events;
        _logger = logger;
    }

    // Observer: dang ky nhan tin khi co su kien moi.
    public void Subscribe(IEventObserver observer)
    {
        _observers.Add(observer);
    }

    public Event CreateEvent(Guid clubId, string title, DateTime date)
    {
        var club = _clubs.GetById(clubId)
            ?? throw new InvalidOperationException("Club not found");

        var ev = new Event { Id = Guid.NewGuid(), ClubId = clubId, Title = title, Date = date };
        _events.Add(ev);

        _logger.Log($"Event created: {title} (CLB: {club.Name})");

        // Observer: bao cho tat ca observer da dang ky, khong can biet ho lam gi.
        foreach (var observer in _observers)
            observer.OnEventCreated(ev);

        return ev;
    }
}
