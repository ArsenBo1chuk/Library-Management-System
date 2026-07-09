using System;
using Library.Interface;
using Library.Enums;
using System.IO;
namespace Library.Services;

public class FileLogger : ILogger
{
    private readonly string path;
    public FileLogger()
    {
        path = "Data/logs.txt";
        if (!Directory.Exists("Data"))
            Directory.CreateDirectory("Data");
        if (!File.Exists(path))
            File.Create(path);
    }

    public void Log(string message, LogLevel level)
    {
        string input;
        switch (level)
        {
            case LogLevel.Info:
                input = $"[INFO] [{DateTime.Now}] {message}\n";
                break;
            case LogLevel.Warning:
                input = $"[WARNING] [{DateTime.Now}] {message}\n";
                break;
            case LogLevel.Error:
                input = $"[ERROR] [{DateTime.Now}] {message}\n";
                break;
            default:
                input = $"[UNKNOW] [{DateTime.Now}] {message}\n";
                break;
        }
        File.AppendAllText(path, input);
    }

    public void Info(string message)
    {
        Log(message, LogLevel.Info);
    }

    public void Warning(string message)
    {
        Log(message, LogLevel.Warning);
    }

    public void Error(string message)
    {
        Log(message, LogLevel.Error);
    }
}