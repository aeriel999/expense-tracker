using ExpenseTracker.Core.Incomes.Current;
using MediatR;

namespace ExpenseTracker.Application.Incomes.AddIncome;

public record AddIncomeCommand(
    Guid CategoryId,
    decimal Amount) : IRequest<Income>;
 