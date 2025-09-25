using ExpenseTracker.Application.Interfaces.Expenses;
using ExpenseTracker.Core.Expenses.Current;
using ExpenseTracker.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTracker.Infrastructure.Repositories;

public class CategoryExpenseRepository(AppDbContext context) : ICategoryExpenseRepository
{
    private readonly DbSet<CategoryExpense> _dbSet = context.Set<CategoryExpense>();


    public async Task<CategoryExpense> AddExpenseAsync(
        CategoryExpense entity, CancellationToken ct = default)
    {
       var entry = await _dbSet.AddAsync(entity, ct);

       await context.SaveChangesAsync(ct);

       return entry.Entity;
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var category = await GetByIdAsync(id, ct);

        if (category == null) return;

        _dbSet.Remove(category);

        await context.SaveChangesAsync(ct);
    }

    public async Task<CategoryExpense?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task<List<CategoryExpense>> GetListAsync(CancellationToken ct = default)
    {
        return await _dbSet
         .Include(c => c.CategoryItems)
         .ToListAsync(ct);
    }

    public async Task UpdateAsync(CategoryExpense entity, CancellationToken ct = default)
    {
        // TODO chech is it work
        _dbSet.Update(entity);

        await context.SaveChangesAsync(ct);
    }

    //public async Task<List<Category>> GetListWithItemsAsync()
    //{
    //    return await _dbSet
    //        .Include(c => c.CategoryItems)
    //        .ToListAsync();
    //}

    public async Task<List<CategoryExpense>> GetWithAmountsAsync(
        DateTime date, CancellationToken ct = default)
    {
        return await _dbSet
        .Include(c => c.CategoryItems!)
            .ThenInclude(ci => ci.Expenses!.Where(e => e.Date == date))
        .ToListAsync(ct);
    }

    public async Task<List<CategoryExpense>> GetWithAmountsAsync(
      DateTime from, DateTime to, CancellationToken ct = default)
    {
        return await _dbSet
            .AsNoTracking()
            .AsSplitQuery()
            .Include(c => c.CategoryItems!)
                .ThenInclude(ci => ci.Expenses!
                    .Where(e => e.Date >= from && e.Date <= to))   // filtered include
            .ToListAsync(ct);
    }

}
