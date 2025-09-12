using ExpenseTracker.Api.Contracts.Incomes;
using ExpenseTracker.Core.Incomes.Current;
using Mapster;

namespace ExpenseTracker.Api.Common.Mapping;

public class IncomeMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CategoryIncome, GetCategoryIncomesResponse>()
             .Map(desp => desp.Id, src => src.CategoryIncomeId)
             .Map(desp => desp.Name, src => src.CategoryIncomeName)
             .Map(desp => desp.IconName, src => src.IconName)
             .Map(desp => desp.Description, src => src.CategoryIncomeDescription);

        config.NewConfig<List<CategoryIncome>, List<GetCategoryIncomesResponse>>();

    }
}
