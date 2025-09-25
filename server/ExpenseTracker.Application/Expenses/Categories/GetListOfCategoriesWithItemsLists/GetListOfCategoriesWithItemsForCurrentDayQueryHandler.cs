using ExpenseTracker.Application.Expenses.Categories.Results;
using ExpenseTracker.Application.Interfaces.Expenses;
using ExpenseTracker.Application.Interfaces.Incomes;
using MapsterMapper;
using MediatR;

namespace ExpenseTracker.Application.Expenses.Categories.GetListOfCategoriesWithItemsLists;

public class GetListOfCategoriesWithItemsForCurrentDayQueryHandler(
    ICategoryExpenseRepository repository, IMapper mapper, IIncomeRepository incomeRepository,
    IExpenseRepository expenseRepository)
    : IRequestHandler<GetListOfCategoriesWithItemsForCurrentDayQuery, GetListCategoriesWithAmountsResult>
{
    public async Task<GetListCategoriesWithAmountsResult> Handle(
        GetListOfCategoriesWithItemsForCurrentDayQuery request, 
        CancellationToken cancellationToken)
    {
        var date = DateTime.UtcNow.Date;

        var categoryList = await repository.GetWithAmountsAsync(date, cancellationToken);

        var mappedCategoryList = mapper.Map<List<CategoryResult>>(categoryList);

        var start = new DateTime(date.Year, date.Month, 1);
        var end = start.AddMonths(1);

        var expensesAmount = await expenseRepository.GetExpensesAmountForMonthAsync(start, end, cancellationToken);

        var incomesAmount = await incomeRepository.GetIncomesAmountForMonthAsync(start, end, cancellationToken);

        var balance = incomesAmount - expensesAmount;

        return new GetListCategoriesWithAmountsResult(mappedCategoryList, expensesAmount, incomesAmount, balance);
    }
}
