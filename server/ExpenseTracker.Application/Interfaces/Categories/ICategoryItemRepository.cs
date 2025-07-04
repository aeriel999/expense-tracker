using ExpenseTracker.Core.Categories;

namespace ExpenseTracker.Application.Interfaces.Categories;

public interface ICategoryItemRepository
{
    Task<CategoryItem?> GetByIdAsync(Guid id);
}
