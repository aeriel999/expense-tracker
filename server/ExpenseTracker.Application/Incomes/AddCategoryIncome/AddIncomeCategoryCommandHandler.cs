using ExpenseTracker.Application.Incomes.Add_CategoryIncome;
using ExpenseTracker.Application.Interfaces.Incomes;
using ExpenseTracker.Core.Incomes.Current;
using MediatR;

namespace ExpenseTracker.Application.Incomes.AddCategoryIncome;

public class AddIncomeCategoryCommandHandler(ICategoryIncomeRepository incomeRepository) 
    : IRequestHandler<AddIncomeCategoryCommand, CategoryIncome>
{
    public async Task<CategoryIncome> Handle(AddIncomeCategoryCommand request, CancellationToken cancellationToken)
    {
        if (await incomeRepository.ExistsByNameAsync(request.CategoryIncomeName, cancellationToken))
            throw new ConflictException("category_income.duplicate_name",
                $"CategoryIncome '{request.CategoryIncomeName}' already exists.");

        var categoryIncome = new CategoryIncome
        {
            CategoryIncomeName = request.CategoryIncomeName,
            CategoryIncomeDescription = request.CategoryIncomeDescription,
        };

        var createdcategoryIncome = await incomeRepository.AddCategoryIncomeAsync(categoryIncome);

        if (createdcategoryIncome == null)
            throw new PersistenceException(
            "Failed to create CategoryIncome.",
            new InvalidOperationException("AddCategoryIncomeAsync returned null"));


        return createdcategoryIncome;
    }
}
