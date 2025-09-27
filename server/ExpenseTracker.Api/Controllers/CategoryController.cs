using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using MediatR;
using ExpenseTracker.Application.Expenses.Categories.GetListOfCategoriesWithItemsLists;


namespace ExpenseTracker.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoryController(ISender mediatr) : ControllerBase
{
    [HttpGet("get-list-of-categories-with-items-lists")]
    public async Task<IActionResult> GetListOfCategoriesWithItemsListsCurrentDayAsync()
    {
        var getListOfCategoriesWithAmount = await mediatr.Send(
            new GetListOfCategoriesWithItemsForCurrentDayQuery());

        return Ok(getListOfCategoriesWithAmount);
    }
}
