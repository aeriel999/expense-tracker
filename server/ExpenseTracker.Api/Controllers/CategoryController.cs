using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using MediatR;
using ExpenseTracker.Application.Categories.GetListOfCategoriesWithItemsLists;
using ExpenseTracker.Api.Contracts.Categories;
using ExpenseTracker.Application.Categories.Results;


namespace ExpenseTracker.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoryController(ISender mediatr, IMapper mapper) : ControllerBase
{
    [HttpGet("get-list-of-categories-with-items-lists")]
    public async Task<IActionResult> GetListOfCategoriesWithItemsListsCurrentDayAsync()
    {
        List<CategoryResult> getListOfCategories = await mediatr.Send(new GetListOfCategoriesWithItemsForCurrentDayQuery());

        var mappedResult = mapper.Map<List<GetCategoryWithItemsResponse>>(getListOfCategories);

        return Ok(mappedResult);
    }
}
