using ExpenseTracker.Application.Categories.Results;
using ExpenseTracker.Core.Categories;
using Mapster;

namespace ExpenseTracker.Application.Common.Mapping;

public class CategoryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CategoryItem, CategoryItemResult>()
           .Map(desp => desp.Id, src => src.Id)
           .Map(desp => desp.Label, src => src.Name)
           .Map(desp => desp.Total, src => src.Expenses!.Sum(e => e.Amount));
    

    }
}
