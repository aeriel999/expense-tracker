namespace ExpenseTracker.Core.Incomes;

public class Income
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public DateOnly DateOnly { get; set; }

    public required decimal Amount { get; set; }
}
