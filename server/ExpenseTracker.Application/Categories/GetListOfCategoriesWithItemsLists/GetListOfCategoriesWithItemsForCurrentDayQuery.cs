using ExpenseTracker.Core.Categories;
using MediatR;

namespace ExpenseTracker.Application.Categories.GetListOfCategoriesWithItemsLists;

public record GetListOfCategoriesWithItemsForCurrentDayQuery() : IRequest<List<Category>>;
 