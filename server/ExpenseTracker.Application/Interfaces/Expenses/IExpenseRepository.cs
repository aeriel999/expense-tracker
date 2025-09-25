using ExpenseTracker.Core.Expenses.Current;

namespace ExpenseTracker.Application.Interfaces.Expenses;

public interface IExpenseRepository
{
    Task<Expense> AddAsync(Expense expense, CancellationToken ct = default);

    Task<decimal> GetExpensesAmountForMonthAsync(
       DateTime start, DateTime end, CancellationToken ct = default);
}
