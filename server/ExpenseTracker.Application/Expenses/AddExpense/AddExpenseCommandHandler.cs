using ExpenseTracker.Application.Interfaces.Expenses;
using ExpenseTracker.Core.Expenses.Current;
using MediatR;

namespace ExpenseTracker.Application.Expenses.AddExpense;

public class AddExpenseCommandHandler(
    IExpenseRepository expenseRepository, ICategoryExpenseItemRepository categoryItemRepository) :
    IRequestHandler<AddExpenseCommand, Expense>
{
    public async Task<Expense> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
    {
        var categoryItem = await categoryItemRepository.GetByIdAsync(request.CategoryItemId);

        if (categoryItem == null) throw new NotFoundException("CategoryItem", request.CategoryItemId);

        var expense = new Expense
        {
            CategoryItemId = request.CategoryItemId,
            Amount = request.Amount,
            Date = DateTime.UtcNow.Date,
        };

        var createdExpense = await expenseRepository.AddAsync(expense);

        if (createdExpense == null)
            throw new DomainRuleViolationException(
                       "expense.create_failed",
                       "Failed to create expense.");

        return createdExpense!;
    }
}

 