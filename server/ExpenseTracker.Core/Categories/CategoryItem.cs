using ExpenseTracker.Core.Expenses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Core.Categories;

public class CategoryItem
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public Guid CategoryId { get; set; }


    [ForeignKey(nameof(CategoryId))]
    public Category? Category { get; set; }

    public ICollection<Expense>? Expenses { get; set; }
}