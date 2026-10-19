using EduHub.Ch02.Domain;
using EduHub.Ch02.Logging;
using EduHub.Ch02.Notifications;
using EduHub.Ch02.Repositories;

namespace EduHub.Ch02.Services;

// SRP: chi lo nghiep vu CLB va thanh vien.
public class ClubService
{
    private readonly IClubRepository _clubs;
    private readonly IMemberRepository _members;
    private readonly IAppLogger _logger;
    private readonly INotificationServiceFactory _notificationFactory;

    // DIP: phu thuoc vao interface, nhan qua constructor.
    public ClubService(
        IClubRepository clubs,
        IMemberRepository members,
        IAppLogger logger,
        INotificationServiceFactory notificationFactory)
    {
        _clubs = clubs;
        _members = members;
        _logger = logger;
        _notificationFactory = notificationFactory;
    }

    public Club CreateClub(
        string name,
        string description,
        string presidentEmail,
        NotificationChannel channel = NotificationChannel.Email)
    {
        // Validation da chuyen vao Domain (Club.Create) — service chi dieu phoi.
        var club = Club.Create(name, description);
        _clubs.Add(club);

        _logger.Log($"Club created: {name}");

        // Factory: chon kenh thong bao ma khong can if/else (OCP).
        var notifier = _notificationFactory.Create(channel);
        notifier.Send(presidentEmail, $"CLB '{name}' da duoc tao thanh cong.");

        return club;
    }

    public void AddMemberToClub(Guid clubId, string memberName, string email)
    {
        var club = _clubs.GetById(clubId)
            ?? throw new InvalidOperationException("Club not found");

        if (!club.HasRoom(_members.CountByClub(clubId)))
            throw new InvalidOperationException("Club is full (max 50 members)");

        var member = new Member
        {
            Id = Guid.NewGuid(),
            Name = memberName,
            Email = email,
            ClubId = clubId
        };
        _members.Add(member);

        _logger.Log($"Member {memberName} joined {club.Name}");

        var notifier = _notificationFactory.Create(NotificationChannel.Email);
        notifier.Send(email, $"Chao mung {memberName} den voi {club.Name}!");
    }
}
