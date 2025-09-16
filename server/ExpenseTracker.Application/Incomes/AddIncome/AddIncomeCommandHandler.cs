using ExpenseTracker.Application.Interfaces.Incomes;
using ExpenseTracker.Core.Incomes.Current;
using MediatR;

namespace ExpenseTracker.Application.Incomes.AddIncome;

public class AddIncomeCommandHandler(
    IIncomeRepository incomeRepository, ICategoryIncomeRepository categoryIncomeRepository) 
    : IRequestHandler<AddIncomeCommand, Income>
{
    public async Task<Income> Handle(AddIncomeCommand request, CancellationToken cancellationToken)
    {
        if (!await categoryIncomeRepository.ExistsByIdAsync(request.CategoryId, cancellationToken))
            throw new NotFoundException(nameof(CategoryIncome), request.CategoryId);

        var income = new Income
        {
            Amount = request.Amount,
            CategoryIncomeId = request.CategoryId,
            Date = DateTime.UtcNow.Date,
        };

        return await incomeRepository.AddIncomeAsync(income, cancellationToken);
    }
}
