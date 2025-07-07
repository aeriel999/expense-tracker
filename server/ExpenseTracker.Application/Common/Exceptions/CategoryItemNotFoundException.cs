namespace ExpenseTracker.Api.Common.Exceptions;

public class CategoryItemNotFoundException : Exception
{
    public CategoryItemNotFoundException(Guid categoryItemId)
       : base($"Category item with ID '{categoryItemId}' was not found.") { }
}
