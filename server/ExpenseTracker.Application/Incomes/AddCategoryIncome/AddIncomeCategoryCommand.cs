using ExpenseTracker.Core.Incomes.Current;
using MediatR;

namespace ExpenseTracker.Application.Incomes.Add_CategoryIncome;

public record AddIncomeCategoryCommand(
    string CategoryIncomeName,
    string CategoryIncomeDescription
    ) : IRequest<CategoryIncome>;
 
