namespace ExpenseTracker.Application.Common.Exceptions;

public class ExpenseCreationFailedException : Exception
{
    public ExpenseCreationFailedException()
        : base("Failed to create expense. Please try again later.") { }
}
