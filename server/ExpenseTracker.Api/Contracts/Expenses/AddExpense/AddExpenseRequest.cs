namespace ExpenseTracker.Api.Contracts.Expenses.AddExpense;

public record AddExpenseRequest(
    Guid CategoryItemId,
    decimal Amount);
 
