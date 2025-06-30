using ExpenseTracker.Api.Contracts.Categories;
using ExpenseTracker.Core.Categories;
using Mapster;

namespace ExpenseTracker.Api.Common.Mapping;

public class CategoryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CategoryItem, GetCategoryItemCurrentDayResponse>()
            .Map(desp => desp.Id, src => src.Id)
            .Map(desp => desp.Name, src => src.Name)
            .Map(desp => desp.Description, src => src.Description);

        config.NewConfig<List<CategoryItem>, List<GetCategoryItemCurrentDayResponse>>();


        config.NewConfig<Category, GetCategoryWithItemsResponse>()
            .Map(desp => desp.Id, src => src.Id)
            .Map(desp => desp.Name, src => src.Name)
            .Map(desp => desp.Description, src => src.Description)
            .Map(desp => desp.IconPath, src => src.IconPath)
            .Map(desp => desp.CategoryItems, src => src.CategoryItems);

        config.NewConfig<List<Category>, List<GetCategoryWithItemsResponse>>();

    }
}
