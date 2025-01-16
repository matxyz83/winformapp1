using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WinFormsApp1;

internal static class Program
{
    [STAThread]
    static async Task Main()
    {
        ApplicationConfiguration.Initialize();

        // Creazione dell'host generico
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // Registrare il form principale
                services
                    .Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)))

                    .AddLogging(cfg =>
                    {
                        cfg.AddProvider(new FileLoggerProvider("app-log.txt"));
                    })

                    .AddSingleton<IAuthService, AuthService>()
                    .AddSingleton<IDataService, DataService>()
                    .AddSingleton<CancellationTokenSource>()

                    .AddSingleton<FormMain>()
                    .AddSingleton<FormLogin>();


                // Registrare il servizio in background
                services.AddHostedService<BackgroundWorkerService>();
            })
            .Build();

        // Avvio dell'host in un thread separato
        Task.Run(() => host.RunAsync());


        var service = host.Services.GetRequiredService<IAuthService>();

        // Avviare il form principale
        var form = host.Services.GetRequiredService<FormMain>();
        Application.Run(form);


        await service.WaitServiceClose();


    }
}


public class BackgroundWorkerService : BackgroundService
{

    private readonly ILogger<BackgroundWorkerService> _logger;
    private readonly IAuthService _authService;

    public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("BackgroundWorkerService avviato.");

        _authService.RegisterService("service");

        // Combina i token per supportare la cancellazione da entrambi
        var linkedToken = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken, _authService.CancellationToken).Token;

        while (!linkedToken.IsCancellationRequested)
        {

            _logger.LogInformation($"Background service eseguito alle: {DateTime.Now}");
            try
            {
                await Task.Delay(5000);
            }
            catch (TaskCanceledException)
            {
                _logger.LogInformation("Task cancellato.");
            }
        }

        _authService.UnregisterService("service");

        _logger.LogInformation("BackgroundWorkerService terminato.");
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        return base.StopAsync(cancellationToken);
    }
}
