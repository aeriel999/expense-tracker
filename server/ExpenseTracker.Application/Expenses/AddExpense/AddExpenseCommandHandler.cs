using ExpenseTracker.Application.Interfaces.Expenses;
using ExpenseTracker.Core.Expenses.Current;
using MediatR;

namespace ExpenseTracker.Application.Expenses.AddExpense;


public class AddExpenseCommandHandler(
    IExpenseRepository expenseRepository, ICategoryExpenseItemRepository categoryItemRepository) 
    : IRequestHandler<AddExpenseCommand, AddExpenseCommandResult>
{
    public async Task<AddExpenseCommandResult> Handle(
        AddExpenseCommand request, CancellationToken cancellationToken)
    {
        if (!await categoryItemRepository.ExistsByIdAsync(request.CategoryId, cancellationToken))
            throw new NotFoundException("CategoryItem", request.CategoryId);

        var expense = new Expense
        {
            CategoryItemId = request.CategoryId,
            Amount = request.Amount,
            Date = DateTime.UtcNow.Date,
        };

        var createdExpense = await expenseRepository.AddAsync(expense, cancellationToken);

        var categoryId = await categoryItemRepository.GetCategoryIdByCategoryItemIdAsync(
            createdExpense.CategoryItemId, cancellationToken);

        return new AddExpenseCommandResult(categoryId, request.Amount);
    }
}

 