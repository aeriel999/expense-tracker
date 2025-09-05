using ExpenseTracker.Core.Expenses.Current;
using MediatR;

namespace ExpenseTracker.Application.Expenses.AddExpense;

public record AddExpenseCommand(
    Guid CategoryItemId,
    decimal Amount) : IRequest<Expense>;
 
