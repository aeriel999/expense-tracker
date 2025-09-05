using ExpenseTracker.Core.Expenses.Current;
using ExpenseTracker.Core.Incomes.Current;
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
    public DbSet<CategoryExpense> Categories { get; set; }


    /// <summary>
    /// Підкатегорії/елементи категорій (наприклад: Electricity в Utilities).
    /// </summary>
    public DbSet<CategoryExpenseItem> CategoryItems { get; set; }


    /// <summary>
    /// Витрати користувача (прив’язані до конкретного CategoryItem).
    /// </summary>
    public DbSet<Expense> Expenses { get; set; }


    /// <summary>
    /// Доходи користувача (транзакції без деталізації по категоріях).
    /// </summary>
    public DbSet<Income> Incomes { get; set; }


    /// <summary>
    /// Категорії доходів (зарплата, подарунок, підробіток тощо).
    /// </summary>
    public DbSet<CategoryIncome> CategoryIncomes { get; set; }


    /// <summary>
    /// Конфігурація зв’язків між сутностями.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ===================== EXPENSES =====================
        // Category 1..* CategoryItems
        // Коли видаляємо Category – CategoryItems не видаляються каскадно.
        modelBuilder.Entity<CategoryExpense>()
            .HasMany(c => c.CategoryItems)
            .WithOne(c => c.Category)
            .OnDelete(DeleteBehavior.Restrict);

        // CategoryItem 1..* Expenses
        // Коли видаляємо CategoryItem – Expenses не видаляються каскадно.
        modelBuilder.Entity<CategoryExpenseItem>()
            .HasMany(i => i.Expenses)
            .WithOne(e => e.CategoryItem)
            .OnDelete(DeleteBehavior.Restrict);


        // ===================== INCOMES =====================
        // CategoryIncome 1..* Incomes
        // Коли видаляємо CategoryIncome – Incomes не видаляються каскадно.
        modelBuilder.Entity<CategoryIncome>()
            .HasMany(c => c.Incomes)
            .WithOne(i => i.CategoryIncome)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
