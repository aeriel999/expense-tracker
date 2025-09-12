using ExpenseTracker.Api.Contracts.Categories;
using ExpenseTracker.Api.Contracts.Expenses.AddExpense;
using ExpenseTracker.Application.Expenses.AddExpense;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ExpenseController(ISender mediatr, IMapper mapper) : ControllerBase
{
    [HttpPost("add-expense")]
    public async Task<IActionResult> AddExpenseAsync(AddExpenseRequest expense)
    {
        var addExpense = await mediatr.Send(mapper.Map<AddExpenseCommand>(expense));

        return Ok(mapper.Map<List<GetCategoryWithItemsResponse>>(addExpense));
    }
}
