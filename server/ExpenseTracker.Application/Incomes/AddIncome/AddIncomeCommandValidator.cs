using FluentValidation;

namespace ExpenseTracker.Application.Incomes.AddIncome;

public class AddIncomeCommandValidator : AbstractValidator<AddIncomeCommand>
{
    public AddIncomeCommandValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than 0");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required");
    }
}
