namespace ExpenseTracker.Application.Categories.Results;

public record CategoryResult(
    Guid Id,
    string Title,
    string? Icon,
    decimal Amount,
    List<CategoryItemResult> Items);
 
