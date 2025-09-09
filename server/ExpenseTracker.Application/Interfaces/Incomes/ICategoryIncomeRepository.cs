using ExpenseTracker.Core.Incomes.Current;

namespace ExpenseTracker.Application.Interfaces.Incomes;

public interface ICategoryIncomeRepository
{
    Task<CategoryIncome> AddCategoryIncomeAsync(CategoryIncome categoryIncome);
}
