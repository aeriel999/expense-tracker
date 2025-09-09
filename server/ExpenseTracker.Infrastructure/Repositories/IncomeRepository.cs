using ExpenseTracker.Application.Interfaces.Incomes;
using ExpenseTracker.Core.Incomes.Current;
using ExpenseTracker.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories;

public class IncomeRepository(AppDbContext context) : IIncomeRepository
{
    private readonly DbSet<Income> _dbSet = context.Set<Income>();

    public async Task<Income> AddAsync(Income income, CancellationToken ct = default)
    {
       var entry = await _dbSet.AddAsync(income);

        await context.SaveChangesAsync();

        return entry.Entity;
    }
}
