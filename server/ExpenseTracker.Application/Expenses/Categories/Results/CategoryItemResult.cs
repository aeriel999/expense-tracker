namespace ExpenseTracker.Application.Expenses.Categories.Results;

public record CategoryItemResult(
    Guid Id,
    string Name,
    decimal Total);
 
