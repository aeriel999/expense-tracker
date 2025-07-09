namespace ExpenseTracker.Application.Categories.Results;

public record CategoryResult(
    Guid Id,
    string Name,
    string? IconPath,
    decimal Amount,
    List<CategoryItemResult> CategoryItems);
 
