namespace ExpenseTracker.Application.Incomes.GetCategoryIncomesListWithAmount;

public record CategoryIncomeResponse(
    Guid CategoryId,
    string CategoryName,
    string? IconName,
    decimal Amount);
