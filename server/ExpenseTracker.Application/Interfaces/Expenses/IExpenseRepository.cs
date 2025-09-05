using ExpenseTracker.Core.Expenses.Current;

namespace ExpenseTracker.Application.Interfaces.Expenses;

public interface IExpenseRepository
{
    Task<Expense?> AddAsync(Expense expense);
}
