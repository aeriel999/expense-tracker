using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Core.Expenses.Current;

public class CategoryExpenseItem
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public Guid CategoryId { get; set; }


    [ForeignKey(nameof(CategoryId))]
    public CategoryExpense? Category { get; set; }

    public ICollection<Expense>? Expenses { get; set; }
}