using ExpenseTracker.Core.Incomes.Current;

namespace ExpenseTracker.Application.Interfaces.Incomes;

public interface IIncomeRepository
{
    Task<Income>AddIncomeAsync(Income income, CancellationToken ct = default);

    Task<decimal>GetAmountForMonthAsync(DateTime start, DateTime end, CancellationToken ct = default); 
}
