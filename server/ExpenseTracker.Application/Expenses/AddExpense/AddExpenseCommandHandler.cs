using ExpenseTracker.Api.Common.Exceptions;
using ExpenseTracker.Application.Common.Exceptions;
using ExpenseTracker.Application.Interfaces.Categories;
using ExpenseTracker.Application.Interfaces.Expenses;
using ExpenseTracker.Core.Expenses;
using MediatR;

namespace ExpenseTracker.Application.Expenses.AddExpense;

public class AddExpenseCommandHandler(
    IExpenseRepository expenseRepository, ICategoryItemRepository categoryItemRepository) :
    IRequestHandler<AddExpenseCommand, Expense>
{
    public async Task<Expense> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
    {
        var categoryItem = await categoryItemRepository.GetByIdAsync(request.CategoryItemId);

        if (categoryItem == null) throw new CategoryItemNotFoundException(request.CategoryItemId);

        var expense = new Expense
        {
            CategoryItemId = request.CategoryItemId,
            Amount = request.Amount,
            Date = DateTime.UtcNow.Date,
        };

        var createdExpense = await expenseRepository.AddAsync(expense);

        if (createdExpense == null) throw new ExpenseCreationFailedException();

        return createdExpense!;
    }
}

 