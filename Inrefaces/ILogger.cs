using Library.Enums;
namespace Library.Interface;

public interface ILogger
{
    void Info(string message);

    void Warning(string message);

    void Error(string message);

    void Log(string message, LogLevel level);
}