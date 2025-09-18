namespace ExpenseTracker.Application.Expenses.Categories.Results;

public record GetListCategoriesWithAmountsResult(
    List<CategoryResult> CategoryResultsList,
    decimal ExpensesAmount,
    decimal IncomesAmount,
    decimal Balance);
 