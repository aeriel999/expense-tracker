namespace ExpenseTracker.Application.Expenses.AddExpense;

public record AddExpenseCommandResult(
    Guid ExpenseCategoryId,
    decimal CurrentCategoryAmount);
 
