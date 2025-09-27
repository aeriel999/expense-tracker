using ExpenseTracker.Core.Expenses.Current;

namespace ExpenseTracker.Application.Interfaces.Expenses;

public interface ICategoryExpenseItemRepository
{
    Task<bool> ExistsByIdAsync(Guid id, CancellationToken ct = default);
}
