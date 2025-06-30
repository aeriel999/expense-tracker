using ExpenseTracker.Core.Categories;

namespace ExpenseTracker.Application.Interfaces.Categories;

public interface ICategoryRepository 
{
    Task<Category?> GetByIdAsync(Guid id);

    Task<List<Category>?> GetListAsync();

    Task<Category?> AddAsync(Category category);

    Task UpdateAsync(Category category);

    Task DeleteAsync(Guid id);
}
