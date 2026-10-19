using EduHub.Ch02.Patterns.Strategies;
using EduHub.Ch02.Repositories;

namespace EduHub.Ch02.Services;

public class ReportService
{
    private readonly IClubRepository _clubs;
    private readonly IMemberRepository _members;

    public ReportService(IClubRepository clubs, IMemberRepository members)
    {
        _clubs = clubs;
        _members = members;
    }

    // Strategy: cach xuat bao cao do caller quyet dinh thong qua strategy truyen vao.
    public void GenerateReport(IReportStrategy strategy)
    {
        var rows = _clubs.GetAll()
            .Select(c => new ClubReportRow(c.Name, _members.CountByClub(c.Id)))
            .ToList();

        strategy.Generate(rows);
    }
}
