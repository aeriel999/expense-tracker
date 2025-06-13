using ExpenseTracker.Application.Interfaces.Categories;
using ExpenseTracker.Core.Categories;
using ExpenseTracker.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTracker.Infrastructure.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository<Category>
{
    private readonly DbSet<Category> _dbSet = context.Set<Category>();


    public async Task<Category?> AddAsync(Category entity)
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

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _dbSet.Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Category>?> GetListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public Task UpdateAsync(Category entity)
    {
        // TODO chech is it work
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public async Task<List<Category>> GetListWithItemsAsync()
    {
        return await _dbSet
            .Include(c => c.CategoryItems)
            .ToListAsync();
    }
}
