using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite; // для роботи з SQLite
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ExpenseTracker.Infrastructure.Common.Persistence;

namespace ExpenseTracker.Infrastructure.Common.Initializers;

public static class DbBootstrapper
{
    /// <summary>
    /// Основна точка: перевіряє, що каталог існує,
    /// накатує всі міграції і запускає сидери.
    /// Викликається з Program.cs при старті.
    /// </summary>
    public static async Task EnsureMigratedAndSeededAsync(IHost app)
    {
        using var scope = app.Services.CreateScope();

        var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // 1) Створюємо папку для SQLite (якщо нема)
        EnsureSqliteDirectoryExists(db.Database.GetDbConnection(), env.ContentRootPath);

        // 2) Виконуємо міграції (створює файл .db + таблиці)
        await db.Database.MigrateAsync();

        // 3) Виконуємо сидинг початкових даних
        await ExpenseTrackerInitializer.SeedCategoriesDataAsync(app);
    }

    /// <summary>
    /// Витягує шлях до файлу SQLite і створює папку для нього.
    /// </summary>
    private static void EnsureSqliteDirectoryExists(DbConnection connection, string contentRoot)
    {
        // Витягуємо data source (шлях до файлу .db) з connection string
        string dataSource;

        if (connection is SqliteConnection sqliteConn && !string.IsNullOrWhiteSpace(sqliteConn.DataSource))
        {
            dataSource = sqliteConn.DataSource;
        }
        else
        {
            var builder = new SqliteConnectionStringBuilder(connection.ConnectionString);
            dataSource = builder.DataSource;
        }

        // Робимо абсолютний шлях (якщо він був відносний)
        var fullPath = Path.IsPathRooted(dataSource)
            ? dataSource
            : Path.GetFullPath(dataSource, contentRoot);

        // Створюємо каталог (файл створиться EF-ом автоматично)
        var dir = Path.GetDirectoryName(fullPath);
        if (!string.IsNullOrEmpty(dir))
            Directory.CreateDirectory(dir);
    }
}
