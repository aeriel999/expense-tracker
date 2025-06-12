namespace ExpenseTracker.Core.Categories;

public class Category
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public ICollection<CategoryItem>? CategoryItems { get; set; }

}
