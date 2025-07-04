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

        if (categoryItem == null) 
        {
            
        }

        return new Expense();
    }
}

 