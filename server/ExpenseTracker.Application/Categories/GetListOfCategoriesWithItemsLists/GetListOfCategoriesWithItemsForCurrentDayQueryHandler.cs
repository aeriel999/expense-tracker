using ExpenseTracker.Application.Common.Exceptions;
using ExpenseTracker.Application.Interfaces.Categories;
using ExpenseTracker.Core.Categories;
using MediatR;

namespace ExpenseTracker.Application.Categories.GetListOfCategoriesWithItemsLists;

public class GetListOfCategoriesWithItemsForCurrentDayQueryHandler(ICategoryRepository repository)
    : IRequestHandler<GetListOfCategoriesWithItemsForCurrentDayQuery, List<Category>>
{
    public async Task<List<Category>> Handle(GetListOfCategoriesWithItemsForCurrentDayQuery request, 
        CancellationToken cancellationToken)
    {
        var categoryList = await repository.GetWithAmountsAsync(DateTime.Now, DateTime.Now);

        if (categoryList == null || categoryList.Count == 0)
            throw new DataNotFoundException("No categories with items found.");

        return categoryList;
    }
}
