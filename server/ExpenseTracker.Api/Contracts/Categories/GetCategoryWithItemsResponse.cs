namespace ExpenseTracker.Api.Contracts.Categories;

public record GetCategoryWithItemsResponse
(
    Guid Id,
    string Name,
    string? IconPath,
    decimal Amount,
    List<GetCategoryItemCurrentDayResponse>? CategoryItems
);
