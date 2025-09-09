using ExpenseTracker.Core.Incomes.Current;

namespace ExpenseTracker.Application.Interfaces.Incomes;

public interface IIncomeRepository
{
    Task<Income>AddAsync(Income income);
}
