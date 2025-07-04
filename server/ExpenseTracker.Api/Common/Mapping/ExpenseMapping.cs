using ExpenseTracker.Api.Contracts.Expenses.AddExpense;
using ExpenseTracker.Application.Expenses.AddExpense;
using Mapster;

namespace ExpenseTracker.Api.Common.Mapping;

public class ExpenseMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddExpenseRequest, AddExpenseCommand>()
           .Map(desp => desp.CategoryItemId, src => src.CategoryItemId)
           .Map(desp => desp.Amount, src => src.Amount);
    }
}
