namespace ExpenseTracker.Application.Categories.Results;

public record CategoryResults(
    Guid Id,
    string Title,
    string? Icon,
    decimal Amount,
    List<CategoryItemResult> Items);
 
