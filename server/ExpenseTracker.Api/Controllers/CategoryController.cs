using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using MediatR;
using ExpenseTracker.Api.Contracts.Categories;
using ExpenseTracker.Application.Expenses.Categories.GetListOfCategoriesWithItemsLists;


namespace ExpenseTracker.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoryController(ISender mediatr, IMapper mapper) : ControllerBase
{
    [HttpGet("get-list-of-categories-with-items-lists")]
    public async Task<IActionResult> GetListOfCategoriesWithItemsListsCurrentDayAsync()
    {
        var getListOfCategories = await mediatr.Send(
            new GetListOfCategoriesWithItemsForCurrentDayQuery());

        return Ok(mapper.Map<List<GetCategoryWithItemsResponse>>(getListOfCategories));
    }
}
