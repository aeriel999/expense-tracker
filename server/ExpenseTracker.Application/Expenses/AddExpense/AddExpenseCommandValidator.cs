using FluentValidation;

namespace ExpenseTracker.Application.Expenses.AddExpense;

public class AddExpenseCommandValidator : AbstractValidator<AddExpenseCommand>
{
    public AddExpenseCommandValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than 0");

        RuleFor(x => x.CategoryItemId)
            .NotEmpty().WithMessage("CategoryItemId is required");
    }
}
