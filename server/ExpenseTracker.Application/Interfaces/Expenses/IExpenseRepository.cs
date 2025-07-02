using ExpenseTracker.Core.Categories;
using ExpenseTracker.Core.Expenses;

namespace ExpenseTracker.Application.Interfaces.Expenses;

public interface IExpenseRepository
{
    Task<Expense?> AddAsync(Expense expense);
}
