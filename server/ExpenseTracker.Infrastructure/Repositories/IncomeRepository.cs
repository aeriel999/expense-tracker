using ExpenseTracker.Application.Interfaces.Incomes;
using ExpenseTracker.Core.Incomes.Current;
using ExpenseTracker.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories;

public class IncomeRepository(AppDbContext context) : IIncomeRepository
{
    private readonly DbSet<Income> _dbSet = context.Set<Income>();

    public async Task<Income> AddIncomeAsync(Income income, CancellationToken ct = default)
    {
       var entry = await _dbSet.AddAsync(income, ct);

        await context.SaveChangesAsync(ct);

        return entry.Entity;
    }

    public async Task<decimal> GetAmountForMonthAsync(DateTime start, DateTime end, CancellationToken ct = default)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(i => i.Date >= start && i.Date < end)          
            .SumAsync(i => (decimal?)i.Amount, ct) ?? 0m;          
    }
}
