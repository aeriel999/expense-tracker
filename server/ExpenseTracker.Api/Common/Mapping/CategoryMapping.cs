using ExpenseTracker.Api.Contracts.Categories;
using ExpenseTracker.Application.Categories.Results;
using Mapster;

namespace ExpenseTracker.Api.Common.Mapping;

public class CategoryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CategoryItemResult, GetCategoryItemCurrentDayResponse>()
            .Map(desp => desp.Id, src => src.Id)
            .Map(desp => desp.Name, src => src.Name)
            .Map(desp => desp.Total, src => src.Total);

        config.NewConfig<List<CategoryItemResult>, List<GetCategoryItemCurrentDayResponse>>();


        config.NewConfig<CategoryResult, GetCategoryWithItemsResponse>()
            .Map(desp => desp.Id, src => src.Id)
            .Map(desp => desp.Name, src => src.Name)
            .Map(desp => desp.IconPath, src => src.IconPath)
            .Map(desp => desp.Amount, src => src.Amount)
            .Map(desp => desp.CategoryItems, src => src.CategoryItems);

        config.NewConfig<List<CategoryResult>, List<GetCategoryWithItemsResponse>>();

    }
}
