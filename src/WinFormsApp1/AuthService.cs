using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1;

public interface IAuthService
{
    public void RegisterService(string name);

    public void UnregisterService(string name);

    public Task<(bool, string?)> AuthenticateAsync(string username, string password);

    public void CancelRequest();
    Task WaitServiceClose();

    public string? Token { get; }

    public CancellationToken CancellationToken { get; }

}
internal class AuthService : IAuthService
{
    private readonly CancellationTokenSource _tokenSource;
    private readonly ConcurrentDictionary<string, object?> _concurrentQueue;
    private readonly ILogger<AuthService> _logger;

    public string? Token { get; private set; }

    public AuthService(ILogger<AuthService> logger)
    {
        _tokenSource = new CancellationTokenSource();
        _concurrentQueue = new ConcurrentDictionary<string, object?>();
        _logger = logger;
    }

    public CancellationToken CancellationToken => _tokenSource.Token;

    public async Task<(bool, string?)> AuthenticateAsync(string username, string password)
    {
        await Task.Delay(1000);
        Token = "sadasdfas";

        _logger.LogInformation("proaadadafa");

        return (username == "a", "errore");
    }

    public void CancelRequest()
    {
        _tokenSource.Cancel();
    }

    public void RegisterService(string name)
    {
        _concurrentQueue.TryAdd(name, null);
    }

    public void UnregisterService(string name)
    {
        _concurrentQueue.TryRemove(name, out var val);
    }

    public async Task WaitServiceClose()
    {
        while (_concurrentQueue.Count > 0) 
        {
            await Task.Delay(1000);
        }
    }
}



