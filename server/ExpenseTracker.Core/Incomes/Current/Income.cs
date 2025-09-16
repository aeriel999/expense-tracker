using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Core.Incomes.Current;

public class Income
{
    public Guid Id { get; set; }

    [Required]
    public Guid CategoryIncomeId { get; set; }

    [ForeignKey(nameof(CategoryIncomeId))]  
    public CategoryIncome? CategoryIncome { get; set; }

    public DateTime Date { get; set; }

    public required decimal Amount { get; set; }
}
