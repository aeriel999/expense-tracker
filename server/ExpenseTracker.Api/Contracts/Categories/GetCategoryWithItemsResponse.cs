namespace ExpenseTracker.Api.Contracts.Categories;

public record GetCategoryWithItemsResponse
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? IconPath { get; set; }

    public List<GetCategoryItemCurrentDayResponse>? CategoryItems { get; set; }
}
