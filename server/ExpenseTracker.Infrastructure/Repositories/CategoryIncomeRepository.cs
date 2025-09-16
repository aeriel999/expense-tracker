using ExpenseTracker.Application.Interfaces.Incomes;
using ExpenseTracker.Core.Incomes.Current;
using ExpenseTracker.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories;

public class CategoryIncomeRepository(AppDbContext context) : ICategoryIncomeRepository
{
    private readonly DbSet<CategoryIncome> _dbSet = context.Set<CategoryIncome>();

    public async Task<CategoryIncome> AddCategoryIncomeAsync(
        CategoryIncome categoryIncome, CancellationToken ct = default)
    {
        var entry = await _dbSet.AddAsync(categoryIncome, ct);

        await context.SaveChangesAsync(ct);

        return entry.Entity;
    }

    public Task<bool> ExistsByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _dbSet.AnyAsync(x => x.CategoryIncomeId == id, ct);
    }

    public Task<bool> ExistsByNameAsync(string name, CancellationToken ct = default)
    {
        var normalized = name.Trim();

        return _dbSet.AnyAsync(x =>
            x.CategoryIncomeName.ToUpper() == normalized.ToUpper(), ct);
    }

    public async Task<List<CategoryIncome>> GetCategoryIncomesListAsync(CancellationToken ct = default)
    {
        return await _dbSet.ToListAsync(ct);
    }
}
