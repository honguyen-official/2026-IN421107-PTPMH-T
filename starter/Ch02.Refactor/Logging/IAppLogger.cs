namespace EduHub.Ch02.Logging;

// Abstraction cho viec ghi log: service chi biet IAppLogger,
// khong can biet log ghi ra console hay file.
public interface IAppLogger
{
    void Log(string message);
}
