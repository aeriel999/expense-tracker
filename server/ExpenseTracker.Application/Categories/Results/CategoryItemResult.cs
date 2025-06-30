namespace ExpenseTracker.Application.Categories.Results;

public record CategoryItemResult(
    Guid Id,
    string Label,
    decimal Total);
 
