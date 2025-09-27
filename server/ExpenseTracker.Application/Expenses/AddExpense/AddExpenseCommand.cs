using MediatR;

namespace ExpenseTracker.Application.Expenses.AddExpense;

public record AddExpenseCommand(
    Guid CategoryId,
    decimal Amount) : IRequest<AddExpenseCommandResult>;
 
