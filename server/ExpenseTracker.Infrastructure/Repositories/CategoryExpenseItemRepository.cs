using ExpenseTracker.Application.Interfaces.Expenses;
using ExpenseTracker.Core.Expenses.Current;
using ExpenseTracker.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTracker.Infrastructure.Repositories;

public class CategoryExpenseItemRepository(AppDbContext context) : ICategoryExpenseItemRepository
{
    private readonly DbSet<CategoryExpenseItem> _dbSet = context.Set<CategoryExpenseItem>();


    public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _dbSet.AnyAsync(c => c.Id == id, ct);
    }

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

    //public async Task DeleteAsync(Guid id)
    //{
    //    var category = await GetByIdAsync(id);
    //    if (category == null) return;

    //    _dbSet.Remove(category);
    //}



    //public async Task<List<CategoryItem>?> GetListAsync()
    //{
    //    return await _dbSet.ToListAsync();
    //}

    //public Task UpdateAsync(CategoryItem entity)
    //{
    //    // TODO chech is it work
    //    _dbSet.Update(entity);
    //    return Task.CompletedTask;
    //}
}
