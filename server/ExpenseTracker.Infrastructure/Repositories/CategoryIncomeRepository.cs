using ExpenseTracker.Application.Interfaces.Incomes;
using ExpenseTracker.Core.Incomes.Current;
using ExpenseTracker.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories;

public class CategoryIncomeRepository(AppDbContext context) : ICategoryIncomeRepository
{
    private readonly DbSet<CategoryIncome> _dbSet = context.Set<CategoryIncome>();

    public async Task<CategoryIncome> AddCategoryIncomeAsync(CategoryIncome categoryIncome)
    {
        var entry = await _dbSet.AddAsync(categoryIncome);

        await context.SaveChangesAsync();

        return entry.Entity;
    }
}
