using EduHub.Ch02.Domain;

namespace Ch02.Refactor.Tests;

// Mau AAA: Arrange (chuan bi) - Act (thuc hien) - Assert (kiem tra).
// Moi test chi kiem tra MOT hanh vi. Dat ten: TenMethod_TinhHuong_KetQuaMongDoi.
public class DomainTests
{
    private static Event NewEvent()
    {
        return new Event
        {
            Id = Guid.NewGuid(),
            ClubId = Guid.NewGuid(),
            Title = "Workshop SOLID",
            Date = new DateTime(2026, 11, 20)
        };
    }

    [Fact]
    public void CreateClub_WithEmptyName_ThrowsArgumentException()
    {
        // Arrange
        var act = () => Club.Create("", "mo ta");

        // Act + Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Club_Create_WithValidName_ReturnsClub()
    {
        // Arrange
        var name = "Tech Club";

        // Act
        var club = Club.Create(name, "Cau lac bo cong nghe");

        // Assert
        Assert.Equal(name, club.Name);
        Assert.NotEqual(Guid.Empty, club.Id);
    }

    [Fact]
    public void Club_Create_WithInvalidName_ThrowsArgumentException()
    {
        // Arrange
        var emptyName = () => Club.Create("", "mo ta");
        var tooLongName = () => Club.Create(new string('a', 101), "mo ta");

        // Act + Assert
        Assert.Throws<ArgumentException>(emptyName);
        Assert.Throws<ArgumentException>(tooLongName);
    }

    [Fact]
    public void Club_HasRoom_AtMaxMembers_ReturnsFalse()
    {
        // Arrange
        var club = Club.Create("Tech Club", "mo ta");

        // Act
        var hasRoomAt49 = club.HasRoom(49);
        var hasRoomAt50 = club.HasRoom(50);

        // Assert
        Assert.True(hasRoomAt49);
        Assert.False(hasRoomAt50);
    }

    [Fact]
    public void Event_Register_NewMember_ReturnsTrue()
    {
        // Arrange
        var ev = NewEvent();
        var memberId = Guid.NewGuid();

        // Act
        var result = ev.Register(memberId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Event_Register_SameMemberTwice_ReturnsFalse()
    {
        // Arrange
        var ev = NewEvent();
        var memberId = Guid.NewGuid();

        // Act
        var first = ev.Register(memberId);
        var second = ev.Register(memberId);

        // Assert
        Assert.True(first);
        Assert.False(second);
    }

    [Fact]
    public void Event_CheckIn_UnregisteredMember_ThrowsInvalidOperationException()
    {
        // Arrange
        var ev = NewEvent();
        var act = () => ev.CheckIn(Guid.NewGuid());

        // Act + Assert
        Assert.Throws<InvalidOperationException>(act);
    }
}
