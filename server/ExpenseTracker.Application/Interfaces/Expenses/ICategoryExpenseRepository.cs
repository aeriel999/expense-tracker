using ExpenseTracker.Core.Expenses.Current;

namespace ExpenseTracker.Application.Interfaces.Expenses;

public interface ICategoryExpenseRepository 
{
    Task<CategoryExpense?> GetByIdAsync(Guid id, CancellationToken ct = default);

    Task<List<CategoryExpense>> GetListAsync(CancellationToken ct = default);

    Task<CategoryExpense> AddExpenseAsync(CategoryExpense category, CancellationToken ct = default);

    Task UpdateAsync(CategoryExpense category, CancellationToken ct = default);

    Task DeleteAsync(Guid id, CancellationToken ct = default);

    Task<List<CategoryExpense>> GetWithAmountsAsync(DateTime date, CancellationToken ct = default);

    Task<List<CategoryExpense>> GetWithAmountsAsync(
        DateTime from, DateTime to, CancellationToken ct = default);
}
