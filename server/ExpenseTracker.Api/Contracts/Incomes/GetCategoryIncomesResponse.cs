namespace ExpenseTracker.Api.Contracts.Incomes;

public record GetCategoryIncomesResponse (
    Guid Id,
    string Name,
    string Description,
    string? IconName);
 
