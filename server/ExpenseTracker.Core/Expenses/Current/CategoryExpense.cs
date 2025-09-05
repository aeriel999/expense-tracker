namespace ExpenseTracker.Core.Expenses.Current;

public class CategoryExpense
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? IconPath { get; set; }

    public ICollection<CategoryExpenseItem>? CategoryItems { get; set; }

}
