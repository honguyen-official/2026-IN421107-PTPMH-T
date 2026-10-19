using EduHub.Ch02.Domain;
using EduHub.Ch02.Logging;

namespace EduHub.Ch02.Repositories;

// Decorator: boc IClubRepository de them viec ghi log
// ma khong can sua class ben trong (OCP).
public class LoggingClubRepository : IClubRepository
{
    private readonly IClubRepository _inner;
    private readonly IAppLogger _logger;

    public LoggingClubRepository(IClubRepository inner, IAppLogger logger)
    {
        _inner = inner;
        _logger = logger;
    }

    public IReadOnlyList<Club> GetAll()
    {
        _logger.Log("Truy van danh sach CLB");
        return _inner.GetAll();
    }

    public Club? GetById(Guid id)
    {
        _logger.Log($"Truy van CLB {id}");
        return _inner.GetById(id);
    }

    public void Add(Club club)
    {
        _logger.Log($"Luu CLB: {club.Name}");
        _inner.Add(club);
    }
}
