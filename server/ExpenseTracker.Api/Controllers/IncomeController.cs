using ExpenseTracker.Api.Contracts.Incomes;
using ExpenseTracker.Application.Incomes.Add_CategoryIncome;
using ExpenseTracker.Application.Incomes.AddIncome;
using ExpenseTracker.Application.Incomes.GetCategoryIncomesList;
using ExpenseTracker.Application.Incomes.GetCategoryIncomesListWithAmount;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncomeController(ISender mediatr, IMapper mapper) : ControllerBase
{
    [HttpPost("add-incomeCategory")]
    public async Task<IActionResult> AddIncomeCategoryAsync(AddIncomeCategoryRequest incomeCategory)
    {
        var addIncomeCategory = await mediatr.Send(mapper.Map<AddIncomeCategoryCommand>(incomeCategory));

        return Ok(addIncomeCategory);
    }

    [HttpGet("get-category-incomes-list")]
    public async Task<IActionResult> GetCategoryIncomesList()
    {
        var getCategoryIncomesList = await mediatr.Send(new GetCategoryIncomesListQuery());

        return Ok(mapper.Map<List<GetCategoryIncomesResponse>>(getCategoryIncomesList));
    }

    [HttpPost("add-income")]
    public async Task<IActionResult> AddIncomeAsync(AddIncomeRequest income)
    {
        var addIncome = await mediatr.Send(mapper.Map<AddIncomeCommand>(income));

        return Ok(addIncome);
    }

    [HttpGet("get-category-incomes-list-with-amount")]
    public async Task<IActionResult> GetCategoryIncomesListWithAmount()
    {
        var getCategoryIncomesListWithAmount = await mediatr.Send(
            new GetCategoryIncomesListWithAmountQuery());

        return Ok(mapper.Map<List<CategoryIncomeResponse>>(getCategoryIncomesListWithAmount));
    }
}
