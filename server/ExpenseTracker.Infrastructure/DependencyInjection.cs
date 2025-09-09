using ExpenseTracker.Application.Interfaces.Expenses;
using ExpenseTracker.Application.Interfaces.Incomes;
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
            opt.UseSqlite(connectionString, b =>
            {
                // Вказуємо збірку, де зберігати міграції
                b.MigrationsAssembly("ExpenseTracker.Infrastructure");
            });

            // Опційно: щоб запити за замовчуванням були "read-only"
            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });


        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryExpenseRepository, CategoryRepository>();
        services.AddScoped<ICategoryExpenseItemRepository, CategoryExpenseItemRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IIncomeRepository, IncomeRepository>();
        services.AddScoped<ICategoryIncomeRepository, CategoryIncomeRepository>();
        
        return services;
    }
}
