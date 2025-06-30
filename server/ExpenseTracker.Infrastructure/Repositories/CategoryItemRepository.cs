using ExpenseTracker.Application.Interfaces.Categories;
using ExpenseTracker.Core.Categories;
using ExpenseTracker.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTracker.Infrastructure.Repositories;

public class CategoryItemRepository(AppDbContext context) : ICategoryItemRepository
{
    private readonly DbSet<CategoryItem> _dbSet = context.Set<CategoryItem>();

    public async Task<List<CategoryItem>?> GetListAsync(Guid categoryItemId)
    {
        return await _dbSet
         .Include(c => c.Expenses)
         .Where(e => e.)
         .ToListAsync();
    }

    //public async Task<CategoryItem?> AddAsync(CategoryItem entity)
    //{
    //    await _dbSet.AddAsync(entity);

    //    return entity;
    //}

    //public async Task DeleteAsync(Guid id)
    //{
    //    var category = await GetByIdAsync(id);
    //    if (category == null) return;

    //    _dbSet.Remove(category);
    //}

    //public async Task<CategoryItem?> GetByIdAsync(Guid id)
    //{
    //    return await _dbSet.Where(p => p.Id == id)
    //        .FirstOrDefaultAsync();
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
