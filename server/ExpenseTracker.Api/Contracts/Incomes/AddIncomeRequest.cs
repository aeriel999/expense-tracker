using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.Contracts.Incomes;

public class AddIncomeRequest
{
    public Guid CategoryIncomeId { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public required decimal Amount { get; set; }
}
