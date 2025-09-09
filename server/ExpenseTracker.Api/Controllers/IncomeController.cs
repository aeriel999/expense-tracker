using ExpenseTracker.Api.Contracts.Incomes;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncomeController(ISender mediatr, IMapper mapper) : ControllerBase
{
    //[HttpPost("add-income")]
    //public async Task<IActionResult> AddIncomeCategoryAsync(AddIncomeCategoryRequest income)
    //{
    //    var addIncomeCategory = await mediatr.Send(mapper.Map(AddIncomeCategoryCommand));
    //}
}
