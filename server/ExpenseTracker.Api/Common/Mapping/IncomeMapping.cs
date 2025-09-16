using ExpenseTracker.Api.Contracts.Expenses.AddExpense;
using ExpenseTracker.Api.Contracts.Incomes;
using ExpenseTracker.Application.Expenses.AddExpense;
using ExpenseTracker.Application.Incomes.AddIncome;
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
    }
}
