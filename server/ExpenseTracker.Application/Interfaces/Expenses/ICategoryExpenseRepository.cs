using ExpenseTracker.Core.Expenses.Current;

namespace ExpenseTracker.Application.Interfaces.Expenses;

public interface ICategoryExpenseRepository 
{
    Task<CategoryExpense?> GetByIdAsync(Guid id);

    Task<List<CategoryExpense>?> GetListAsync();

    Task<CategoryExpense> AddAsync(CategoryExpense category);

    Task UpdateAsync(CategoryExpense category);

    Task DeleteAsync(Guid id);

    Task<List<CategoryExpense>> GetWithAmountsAsync(DateTime date);

    Task<List<CategoryExpense>> GetWithAmountsAsync(DateTime from, DateTime to);
}
