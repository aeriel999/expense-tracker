using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using MediatR;
using ExpenseTracker.Application.Categories.GetListOfCategoriesWithItemsLists;
using ExpenseTracker.Api.Contracts.Categories;


namespace ExpenseTracker.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoryController(ISender mediatr, IMapper mapper) : ControllerBase
{
    [HttpGet("get-list-of-categories-with-items-lists")]
    public async Task<IActionResult> GetListOfCategoriesWithItemsListsAsync()
    {
        var getListOfCategories = await mediatr.Send(new GetListOfCategoriesWithItemsQuery());

        var mappedResult = mapper.Map<List<GetCategoryWithItemsResponse>>(getListOfCategories);

        return Ok(mappedResult);
    }
}
