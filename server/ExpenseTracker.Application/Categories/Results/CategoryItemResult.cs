namespace ExpenseTracker.Application.Categories.Results;

public record CategoryItemResult(
    Guid Id,
    string Name,
    decimal Total);
 
