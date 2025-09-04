using ExpenseTracker.Core.Categories;
using ExpenseTracker.Core.Expenses;
using ExpenseTracker.Core.Incomes;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTracker.Infrastructure.Common.Persistence;

/// <summary>
/// Головний DbContext для програми.
/// Містить DbSet-и для всіх основних сутностей: категорії, айтеми категорій, витрати та доходи.
/// </summary
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Категорії витрат (наприклад: Household, Medicine, Utilities).
    /// </summary>
    public DbSet<Category> Categories { get; set; }

    /// <summary>
    /// Підкатегорії/елементи категорій (наприклад: Electricity в Utilities).
    /// </summary>
    public DbSet<CategoryItem> CategoryItems { get; set; }

    /// <summary>
    /// Витрати користувача (прив’язані до конкретного CategoryItem).
    /// </summary>
    public DbSet<Expense> Expenses { get; set; }

    /// <summary>
    /// Доходи користувача (загальні, не прив’язані до категорій).
    /// </summary>
    public DbSet<Income> Incomes { get; set; }


    /// <summary>
    /// Конфігурація зв’язків між сутностями.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Category 1..* CategoryItems
        // Коли видаляємо Category – CategoryItems не видаляються каскадно.
        modelBuilder.Entity<Category>()
            .HasMany(c => c.CategoryItems)
            .WithOne(c => c.Category)
            .OnDelete(DeleteBehavior.Restrict);

        // CategoryItem 1..* Expenses
        // Коли видаляємо CategoryItem – Expenses не видаляються каскадно.
        modelBuilder.Entity<CategoryItem>()
            .HasMany(i => i.Expenses)
            .WithOne(e => e.CategoryItem)
            .OnDelete(DeleteBehavior.Restrict);
 
    }
}
