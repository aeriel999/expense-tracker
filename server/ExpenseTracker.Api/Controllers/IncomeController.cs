using ExpenseTracker.Api.Contracts.Incomes;
using ExpenseTracker.Application.Incomes.Add_CategoryIncome;
using ExpenseTracker.Application.Incomes.GetCategoryIncomesList;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncomeController(ISender mediatr, IMapper mapper) : ControllerBase
{
    [HttpPost("add-category-income")]
    public async Task<IActionResult> AddIncomeCategoryAsync(AddIncomeCategoryRequest income)
    {
        var addIncomeCategory = await mediatr.Send(mapper.Map<AddIncomeCategoryCommand>(income));

        return Ok(addIncomeCategory);
    }

    [HttpGet("get-category-incomes-list")]
    public async Task<IActionResult> GetCategoryIncomesList()
    {
        var getCategoryIncomesList = await mediatr.Send(new GetCategoryIncomesListQuery());

        return Ok(mapper.Map<List<GetCategoryIncomesResponse>>(getCategoryIncomesList));
    }
}
