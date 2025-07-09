namespace ExpenseTracker.Api.Contracts.Categories;


public record GetCategoryItemCurrentDayResponse
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required decimal Value { get; set; }

    public string? Description { get; set; }


}
