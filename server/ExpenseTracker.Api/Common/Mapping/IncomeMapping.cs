using ExpenseTracker.Api.Contracts.Incomes;
using ExpenseTracker.Application.Incomes.AddIncome;
using ExpenseTracker.Application.Incomes.GetCategoryIncomesListWithAmount;
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

        config.NewConfig<AddIncomeRequest, AddIncomeCommand>()
          .Map(desp => desp.CategoryId, src => src.CategoryIncomeId)
          .Map(desp => desp.Amount, src => src.Amount);

        config.NewConfig<CategoryIncome, CategoryIncomeResponse>()
          .Map(desp => desp.CategoryId, src => src.CategoryIncomeId)
          .Map(desp => desp.CategoryName, src => src.CategoryIncomeName)
          .Map(desp => desp.Amount, src => src.Incomes != null ? src.Incomes.Sum(e => e.Amount) : 0);

        config.NewConfig<List<CategoryIncome>, List<CategoryIncomeResponse>>();
    }
}
