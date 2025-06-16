using ExpenseTracker.Application.Interfaces.Categories;
using ExpenseTracker.Core.Categories;
using ExpenseTracker.Infrastructure.Common.Persistence;
using ExpenseTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddPersistence(configuration)
            .AddRepositories();

        return services;
    }

    public static IServiceCollection AddPersistence(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlite(connectionString);

            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository<Category>, CategoryRepository>();
        services.AddScoped<ICategoryRepository<CategoryItem>, CategoryItemRepository>();

        return services;
    }
}
