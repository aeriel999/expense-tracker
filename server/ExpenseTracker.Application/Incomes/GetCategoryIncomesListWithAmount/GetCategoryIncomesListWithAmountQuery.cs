using ExpenseTracker.Core.Incomes.Current;
using MediatR;

namespace ExpenseTracker.Application.Incomes.GetCategoryIncomesListWithAmount;

public record GetCategoryIncomesListWithAmountQuery() : IRequest<List<CategoryIncome>>;