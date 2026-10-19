namespace EduHub.Ch02.Domain;

/// <summary>Câu lạc bộ. Quy tắc nghiệp vụ nên nằm ở đây, không nằm trong ClubManager.</summary>
public class Club
{
    public const int MaxMembers = 50;
    public const int MaxNameLength = 100;

    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    // Chuyen luat kiem tra ten tu ClubManager.CreateClub vao day (buoc 4).
    // Ten rong/toan khoang trang -> ArgumentException; dai hon MaxNameLength -> ArgumentException.
    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Club name is required");

        if (name.Length > MaxNameLength)
            throw new ArgumentException("Club name too long");

        return new Club { Id = Guid.NewGuid(), Name = name, Description = description };
    }

    // Tra ve true khi so thanh vien hien tai con nho hon MaxMembers.
    public bool HasRoom(int currentMemberCount)
    {
        return currentMemberCount < MaxMembers;
    }
}
