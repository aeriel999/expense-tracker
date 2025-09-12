using ExpenseTracker.Application.Interfaces.Incomes;
using ExpenseTracker.Core.Incomes.Current;
using MediatR;

namespace ExpenseTracker.Application.Incomes.GetCategoryIncomesList;

public class GetCategoryIncomesListQueryHandler(ICategoryIncomeRepository categoryIncomeRepository)
    : IRequestHandler<GetCategoryIncomesListQuery, List<CategoryIncome>>
{
    public async Task<List<CategoryIncome>> Handle(
        GetCategoryIncomesListQuery request, CancellationToken cancellationToken)
    {
        return await categoryIncomeRepository.GetCategoryIncomesListAsync(cancellationToken);
    }
}
