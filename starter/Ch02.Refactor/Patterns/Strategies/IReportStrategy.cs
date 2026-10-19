namespace EduHub.Ch02.Patterns.Strategies;

// Strategy: dong goi cach xuat bao cao. Muon them dinh dang moi
// chi can them class moi, khong sua ReportService (OCP).
public interface IReportStrategy
{
    void Generate(IReadOnlyList<ClubReportRow> rows);
}
