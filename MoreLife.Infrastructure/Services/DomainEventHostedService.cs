using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MoreLife.Infrastructure.Services;


public class DomainEventHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            // Aqui você pode configurar o processamento de eventos de domínio, se necessário
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        // Limpeza de recursos, se necessário
        return Task.CompletedTask;
    }
}

