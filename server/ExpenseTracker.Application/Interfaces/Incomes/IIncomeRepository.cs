using ExpenseTracker.Core.Incomes.Current;

namespace ExpenseTracker.Application.Interfaces.Incomes;

public interface IIncomeRepository
{
    Task<Income>AddIncomeAsync(Income income, CancellationToken ct = default);

    Task<decimal>GetIncomesAmountForMonthAsync(DateTime start, DateTime end, CancellationToken ct = default); 
}
