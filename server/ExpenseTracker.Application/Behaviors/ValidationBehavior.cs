using FluentValidation;
using MediatR;

namespace ExpenseTracker.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
            return await next();

        var result = await _validator.ValidateAsync(request, cancellationToken);

        if (!result.IsValid)
        {
            var messages = result.Errors
                .Select(e => $"{e.PropertyName}: {e.ErrorMessage}")
                .ToList();

            throw new ValidationException(string.Join(Environment.NewLine, messages));
        }

        return await next();
    }
}
