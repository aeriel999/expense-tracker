using ExpenseTracker.Application.Categories.Results;
using MediatR;

namespace ExpenseTracker.Application.Categories.GetListOfCategoriesWithItemsLists;

public record GetListOfCategoriesWithItemsForCurrentDayQuery() : IRequest<List<CategoryResults>>;
 