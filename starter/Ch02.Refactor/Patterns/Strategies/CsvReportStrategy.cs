namespace EduHub.Ch02.Patterns.Strategies;

public class CsvReportStrategy : IReportStrategy
{
    public void Generate(IReadOnlyList<ClubReportRow> rows)
    {
        Console.WriteLine("ClubName,MemberCount");
        foreach (var row in rows)
            Console.WriteLine($"{row.ClubName},{row.MemberCount}");
    }
}
