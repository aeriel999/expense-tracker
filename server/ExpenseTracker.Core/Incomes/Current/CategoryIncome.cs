namespace ExpenseTracker.Core.Incomes.Current;

public class CategoryIncome
{
    public Guid CategoryIncomeId { get; set; }

    public required string CategoryIncomeName { get; set; }

    public string? CategoryIncomeDescription { get; set; }

    public string? IconName { get; set; }

    public ICollection<Income>? Incomes { get; set; }
}
