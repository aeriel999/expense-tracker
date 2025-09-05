using ExpenseTracker.Application.Interfaces.Categories;
using ExpenseTracker.Core.Expenses.Current;
using ExpenseTracker.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTracker.Infrastructure.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    private readonly DbSet<CategoryExpense> _dbSet = context.Set<CategoryExpense>();


    public async Task<CategoryExpense?> AddAsync(CategoryExpense entity)
    {
       await _dbSet.AddAsync(entity);

       return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await GetByIdAsync(id);
        if (category == null) return;

        _dbSet.Remove(category);
    }

    public async Task<CategoryExpense?> GetByIdAsync(Guid id)
    {
        return await _dbSet.Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<CategoryExpense>?> GetListAsync()
    {
        return await _dbSet
         .Include(c => c.CategoryItems)
         .ToListAsync();
    }

    public Task UpdateAsync(CategoryExpense entity)
    {
        // TODO chech is it work
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    //public async Task<List<Category>> GetListWithItemsAsync()
    //{
    //    return await _dbSet
    //        .Include(c => c.CategoryItems)
    //        .ToListAsync();
    //}

    public async Task<List<CategoryExpense>> GetWithAmountsAsync(DateTime date)
    {
        return await _dbSet
        .Include(c => c.CategoryItems!)
            .ThenInclude(ci => ci.Expenses!.Where(e => e.Date == date))
        .ToListAsync();
    }
    public async Task<List<CategoryExpense>> GetWithAmountsAsync(DateTime from, DateTime to)
    {
        return await _dbSet
        .Include(c => c.CategoryItems!)
            .ThenInclude(ci => ci.Expenses)
            //.Where(e => e.Date >= from && e.Date <= to))
        .ToListAsync();
    }


}
