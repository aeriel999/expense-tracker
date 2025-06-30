using ExpenseTracker.Core.Categories;
using MediatR;

namespace ExpenseTracker.Application.Categories.GetCategoriesWithItemsForCurrentDay;

public record GetCategoriesWithItemsForCurrentDayQuery() : IRequest<List<Category>>;
 