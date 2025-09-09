using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.Contracts.Incomes;

public class AddIncomeCategoryRequest
{
    [Required]
    [StringLength(100, MinimumLength = 3,
         ErrorMessage = "Category name must be between 3 and 100 characters.")]
    public required string CategoryIncomeName { get; set; }

    [StringLength(250,
        ErrorMessage = "Description cannot exceed 250 characters.")]
    public string? CategoryIncomeDescription { get; set; }
}
