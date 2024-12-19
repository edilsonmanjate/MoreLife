using FluentValidation;
using FluentValidation.AspNetCore;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using MoreLife.Application.Common.Behavior;
using MoreLife.Application.Features.Donations.Command.CreateDonationCommand;
using MoreLife.Application.Features.Donators.Command.CreateDonatorCommand;
using MoreLife.Application.Features.Donators.Command.DeleteDonatorCommand;
using MoreLife.Application.Features.Donators.Command.UpdateDonatorCommand;

using System.Reflection;

namespace MoreLife.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddMediator()
            .AddValidation()
            .AddServices();

        return services;
    }



    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            .AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>))
            .AddSingleton(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
           
            

        return services;
    }
    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateDonatorCommand).Assembly); });

        return services;
    }

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddFluentValidationAutoValidation()

            .AddValidatorsFromAssemblyContaining<CreateDonatorCommand>()
            .AddValidatorsFromAssemblyContaining<UpdateDonatorCommand>()
            .AddValidatorsFromAssemblyContaining<DeleteDonatorCommand>()


            .AddValidatorsFromAssemblyContaining<CreateDonationCommand>()
            .AddValidatorsFromAssemblyContaining<CreateDonationCommand>()
            .AddValidatorsFromAssemblyContaining<CreateDonationCommand>()


            ;

        return services;
    }
}