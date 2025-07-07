using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.Contracts.Expenses.AddExpense;

public class AddExpenseRequest
{
   public Guid CategoryItemId { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public required decimal Amount { get; set; }
}
 
