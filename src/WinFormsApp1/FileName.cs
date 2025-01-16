using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public DateTime DateTime { get; set; }
}

public class GenericResult<T>
{
    public bool Success { get; set; }
    public T? Value { get; set; }

    public string? Message { get; set; }
}

public class ListResult<T>
{
    public bool Success { get; set; }

    public IEnumerable<T>? Items { get; set; }

    public string? Message { get; set; }
}

public interface IDataService
{

    public Task<ListResult<Item>> GetDataAsync(CancellationToken cancellationToken);
}

public class DataService : IDataService
{
    public async Task<ListResult<Item>> GetDataAsync(CancellationToken cancellationToken)
    {
        return new ListResult<Item>
        {
            Success = true,
            Items = new List<Item>
            {
                new() { Id =  1, Name = "AAAA1", Description = "Descr", DateTime = DateTime.Now, Type = "dada"},
                new() { Id =  2, Name = "AAAA2", Description = "Descr", DateTime = DateTime.Now, Type = "dada"},
                new() { Id =  3, Name = "AAAA3", Description = "Descr", DateTime = DateTime.Now, Type = "dada"},
                new() { Id =  4, Name = "AAAA4", Description = "Descr", DateTime = DateTime.Now, Type = "dada"},
                new() { Id =  5, Name = "AAAA5", Description = "Descr", DateTime = DateTime.Now, Type = "dada"},
                new() { Id =  6, Name = "AAAA6", Description = "Descr", DateTime = DateTime.Now, Type = "dada"},
                new() { Id =  7, Name = "AAAA7", Description = "Descr", DateTime = DateTime.Now, Type = "dada"}
            }
        };
    }
}

public class AppConfig
{
    public string Prova { get; set; }
}


public class FileLogger : ILogger
{
    private readonly string _filePath;
    private readonly object _lock = new();

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public IDisposable BeginScope<TState>(TState state) => null;

    public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        var message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {formatter(state, exception)}";
        lock (_lock)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }
}

public class FileLoggerProvider : ILoggerProvider
{
    private readonly string _filePath;

    public FileLoggerProvider(string filePath)
    {
        _filePath = filePath;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new FileLogger(_filePath);
    }

    public void Dispose() { }
}