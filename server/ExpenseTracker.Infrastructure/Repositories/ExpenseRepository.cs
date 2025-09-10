using ExpenseTracker.Application.Interfaces.Expenses;
using ExpenseTracker.Core.Expenses.Current;
using ExpenseTracker.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories;

public class ExpenseRepository(AppDbContext context) : IExpenseRepository
{
    private readonly DbSet<Expense> _dbSet = context.Set<Expense>();

    //public async Task<List<CategoryItem>?> GetListAsync(Guid categoryItemId)
    //{
    //    return await _dbSet
    //     .Include(c => c.Expenses)
    //     .Where(e => e.)
    //     .ToListAsync();
    //}

    //public async Task<CategoryItem?> AddExpenseAsync(CategoryItem entity)
    //{
    //    await _dbSet.AddExpenseAsync(entity);

    //    return entity;
    //}
    public async Task<Expense> AddAsync(Expense expense, CancellationToken ct = default)
    {
       var entry = await _dbSet.AddAsync(expense, ct);

       await context.SaveChangesAsync(ct);

       return entry.Entity;
    }
}
