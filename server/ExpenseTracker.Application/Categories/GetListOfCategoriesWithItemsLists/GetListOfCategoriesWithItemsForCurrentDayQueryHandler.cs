using ExpenseTracker.Application.Categories.Results;
using ExpenseTracker.Application.Common.Exceptions;
using ExpenseTracker.Application.Interfaces.Categories;
using MapsterMapper;
using MediatR;

namespace ExpenseTracker.Application.Categories.GetListOfCategoriesWithItemsLists;

public class GetListOfCategoriesWithItemsForCurrentDayQueryHandler(
    ICategoryRepository repository, IMapper mapper)
    : IRequestHandler<GetListOfCategoriesWithItemsForCurrentDayQuery, List<CategoryResults>>
{
    public async Task<List<CategoryResults>> Handle(GetListOfCategoriesWithItemsForCurrentDayQuery request, 
        CancellationToken cancellationToken)
    {
        var date = DateTime.UtcNow.Date;

        var categoryList = await repository.GetWithAmountsAsync(date);

        if (categoryList == null || categoryList.Count == 0)
            throw new DataNotFoundException("No categories with items found.");

        var item = categoryList[0].CategoryItems.ToList()[0];

        var itemResult = mapper.Map<CategoryItemResult>(item);

        return new List<CategoryResults>();
    }
}
