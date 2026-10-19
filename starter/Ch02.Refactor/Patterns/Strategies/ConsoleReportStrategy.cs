namespace EduHub.Ch02.Patterns.Strategies;

public class ConsoleReportStrategy : IReportStrategy
{
    public void Generate(IReadOnlyList<ClubReportRow> rows)
    {
        foreach (var row in rows)
            Console.WriteLine($"Club: {row.ClubName} | Members: {row.MemberCount}");
    }
}
