using ExpenseTracker.Core.Expenses.Current;
using MediatR;

namespace ExpenseTracker.Application.Categories.GetCategoriesWithItemsForCurrentDay;

public record GetCategoriesWithItemsForCurrentDayQuery() : IRequest<List<CategoryExpense>>;
 