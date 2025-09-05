namespace ExpenseTracker.Api.Contracts.Incomes;

public class AddIncomeRequest
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Amount { get; set; }
}
