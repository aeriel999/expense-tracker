using ExpenseTracker.Application.Categories.Results;
using ExpenseTracker.Application.Common.Exceptions;
using ExpenseTracker.Application.Interfaces.Categories;
using MapsterMapper;
using MediatR;

namespace ExpenseTracker.Application.Categories.GetListOfCategoriesWithItemsLists;

public class GetListOfCategoriesWithItemsForCurrentDayQueryHandler(
    ICategoryRepository repository, IMapper mapper)
    : IRequestHandler<GetListOfCategoriesWithItemsForCurrentDayQuery, List<CategoryResult>>
{
    public async Task<List<CategoryResult>> Handle(GetListOfCategoriesWithItemsForCurrentDayQuery request, 
        CancellationToken cancellationToken)
    {
        var date = DateTime.UtcNow.Date;

        var categoryList = await repository.GetWithAmountsAsync(date).ConfigureAwait(false);

        if (categoryList == null || categoryList.Count == 0)
            throw new DataNotFoundException("No categories with items found.");

        var categoryResultList = mapper.Map<List<CategoryResult>>(categoryList);

        return categoryResultList;
    }
}
