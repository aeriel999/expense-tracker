public abstract class AppException(
    string code, int status, string message, object? details = null, Exception? inner = null) 
    : Exception(message, inner)
{
    public int Status { get; } = status; public string Code { get; } = code; public object? Details { get; } = details;
}


public sealed class NotFoundException : AppException
{
    public NotFoundException(string entity, object? key = null)
        : base($"{entity.ToLowerInvariant()}.not_found", 404,
            key is null ? $"{entity} not found." : $"{entity} with key '{key}' not found.")
    { }
}


public sealed class ConflictException : AppException
{
    public ConflictException(string code, string message, object? details = null)
        : base(code, 409, message, details) { }
}


public sealed class DomainRuleViolationException : AppException
{
    public DomainRuleViolationException(string code, string message, object? details = null)
        : base(code, 400, message, details) { }
}


public sealed class ValidationFailedException : AppException
{
    public ValidationFailedException(object errors)
        : base("validation.failed", 422, "Validation failed.", errors) { }
}


public sealed class PersistenceException : AppException
{
    public PersistenceException(string message, Exception inner)
        : base("persistence.error", 500, message, null, inner) { }
}
