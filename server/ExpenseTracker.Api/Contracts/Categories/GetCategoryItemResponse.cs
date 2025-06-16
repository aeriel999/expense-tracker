namespace ExpenseTracker.Api.Contracts.Categories;


public record GetCategoryItemResponse
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }
}
