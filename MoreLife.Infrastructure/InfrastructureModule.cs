using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoreLife.Application.Features.Donations.Command.CreateDonationCommand;

using MoreLife.Application.Features.Donations.EventHandlers;
using MoreLife.Application.Repositories;
using MoreLife.Application.Services;
using MoreLife.core.Events;
using MoreLife.Infrastructure.Persistence;
using MoreLife.Infrastructure.Repositories;
using MoreLife.Infrastructure.Services;

namespace MoreLife.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SQLiteConnection");

        services
            .AddDb(connectionString)
            .AddRepositories()
            .AddServices();
        return services;
    }

    private static IServiceCollection AddDb(this IServiceCollection services, string? connectionString)
    {
        //services.AddDbContext<MoreLifeDbContext>(options => options.UseSqlite(connectionString));
        services.AddDbContext<MoreLifeDbContext>(options => options.UseInMemoryDatabase("Library"));

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // Register other services
        services.AddTransient<IPostalCodeService, PostalCodeService>();
        services.AddHostedService<DomainEventHostedService>();
        services.AddScoped<INotificationHandler<DonationCreatedEvent>, DonationCreatedEventHandler>();
        

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IDonatorRepository, DonatorRepository>();
        services.AddScoped<IDonationRepository, DonationRepository>();
        services.AddScoped<IBloodStockRepository, BloodStockRepository>();

        return services;
    }
}
