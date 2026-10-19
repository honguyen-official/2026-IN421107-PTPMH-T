namespace EduHub.Ch02.Domain;

/// <summary>Sự kiện của CLB, kèm danh sách đăng ký và check-in.</summary>
public class Event
{
    public Guid Id { get; set; }
    public Guid ClubId { get; set; }
    public required string Title { get; set; }
    public DateTime Date { get; set; }

    public HashSet<Guid> RegisteredMemberIds { get; } = new();
    public HashSet<Guid> CheckedInMemberIds { get; } = new();

    // Dang ky tham du; tra ve false neu thanh vien da dang ky truoc do.
    public bool Register(Guid memberId)
    {
        return RegisteredMemberIds.Add(memberId);
    }

    // Chi thanh vien da dang ky moi duoc check-in,
    // nguoc lai nem InvalidOperationException.
    public void CheckIn(Guid memberId)
    {
        if (!RegisteredMemberIds.Contains(memberId))
            throw new InvalidOperationException("Member has not registered for this event");

        CheckedInMemberIds.Add(memberId);
    }
}
