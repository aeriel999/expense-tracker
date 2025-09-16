using ExpenseTracker.Application.Interfaces.Incomes;
using ExpenseTracker.Core.Incomes.Current;
using MediatR;

namespace ExpenseTracker.Application.Incomes.GetCategoryIncomesListWithAmount;

public class GetCategoryIncomesListWithAmountQueryHandler(
    ICategoryIncomeRepository categoryIncomeRepository)
    : IRequestHandler<GetCategoryIncomesListWithAmountQuery, List<CategoryIncome>>
{
    public async Task<List<CategoryIncome>> Handle(
        GetCategoryIncomesListWithAmountQuery request, CancellationToken cancellationToken)
    {
        return await categoryIncomeRepository.GetCategoryIncomesListWithAmountAsync(
            DateTime.Now, cancellationToken);
    }
}
