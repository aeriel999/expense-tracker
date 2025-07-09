namespace ExpenseTracker.Api.Contracts.Categories;


public record GetCategoryItemCurrentDayResponse
(
  Guid Id,
  string Name,
  decimal Total 
);
 