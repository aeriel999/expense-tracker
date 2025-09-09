using FluentValidation;

namespace ExpenseTracker.Application.Incomes.Add_CategoryIncome;

public class AddIncomeCategoryCommandValidator : AbstractValidator<AddIncomeCategoryCommand>
{
    public AddIncomeCategoryCommandValidator() {

        RuleFor(x => x.CategoryIncomeName)
           .NotEmpty().WithMessage("CategoryIncomeName is required")
           .Length(3, 100).WithMessage("CategoryIncomeName must be between 3 and 100 characters");

        RuleFor(x => x.CategoryIncomeDescription)
            .MaximumLength(250).WithMessage("CategoryIncomeDescription must not exceed 250 characters");
    }
}
