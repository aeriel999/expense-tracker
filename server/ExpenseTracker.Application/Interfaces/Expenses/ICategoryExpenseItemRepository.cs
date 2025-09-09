using ExpenseTracker.Core.Expenses.Current;

namespace ExpenseTracker.Application.Interfaces.Expenses;

public interface ICategoryExpenseItemRepository
{
    Task<CategoryExpenseItem?> GetByIdAsync(Guid id);
}
