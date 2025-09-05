using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Core.Expenses.Current;

public class Expense
{
    public Guid Id { get; set; }

    [Required]
    public Guid CategoryItemId { get; set; }


    [ForeignKey(nameof(CategoryItemId))]
    public CategoryExpenseItem? CategoryItem { get; set; }

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }
}
