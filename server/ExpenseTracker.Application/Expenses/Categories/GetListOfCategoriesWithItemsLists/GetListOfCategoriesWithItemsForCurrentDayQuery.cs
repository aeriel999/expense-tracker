using ExpenseTracker.Application.Expenses.Categories.Results;
using MediatR;

namespace ExpenseTracker.Application.Expenses.Categories.GetListOfCategoriesWithItemsLists;

public record GetListOfCategoriesWithItemsForCurrentDayQuery() : IRequest<List<CategoryResult>>;
 