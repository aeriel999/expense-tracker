using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using MediatR;


namespace ExpenseTracker.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoryController(ISender mediatr, IMapper mapper) : ControllerBase
{
    //[HttpGet("get-list-categories")]
    //public async Task<IActionResult> GetListOfCategoriesWithItems()
    //{ 

    //}
    [HttpGet("test")]
    public async Task<string> Test()
    {
        return "Test";
    }
    
}
