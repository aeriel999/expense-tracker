using ExpenseTracker.Core.Incomes.Current;
using MediatR;

namespace ExpenseTracker.Application.Incomes.GetCategoryIncomesList;

public record GetCategoryIncomesListQuery() : IRequest<List<CategoryIncome>>;
 
