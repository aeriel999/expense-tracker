using ExpenseTracker.Core.Expenses.Current;

namespace ExpenseTracker.Application.Interfaces.Categories;

public interface ICategoryItemRepository
{
    Task<CategoryExpenseItem?> GetByIdAsync(Guid id);
}
