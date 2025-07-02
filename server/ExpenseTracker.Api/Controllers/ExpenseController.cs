using ExpenseTracker.Api.Contracts.Categories;
using ExpenseTracker.Application.Categories.GetListOfCategoriesWithItemsLists;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ExpenseController(ISender mediatr, IMapper mapper) : ControllerBase
{
    [HttpPost("add-expense")]
    public async Task<IActionResult> GetListOfCategoriesWithItemsListsCurrentDayAsync()
    {
        var getListOfCategories = await mediatr.Send(new GetListOfCategoriesWithItemsForCurrentDayQuery());

        var mappedResult = mapper.Map<List<GetCategoryWithItemsResponse>>(getListOfCategories);

        return Ok(mappedResult);
    }
}
