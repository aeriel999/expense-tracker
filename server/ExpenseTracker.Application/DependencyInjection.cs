namespace ExpenseTracker.Application;
using Microsoft.Extensions.DependencyInjection;
using Mapster;
using MediatR;
using System.Reflection;
using FluentValidation;
using ExpenseTracker.Application.Behaviors;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMappings();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            AppDomain.CurrentDomain.GetAssemblies()));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }

    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        services.AddMapster();

        TypeAdapterConfig.GlobalSettings.Scan(typeof(DependencyInjection).Assembly);

        return services;
    }

}
