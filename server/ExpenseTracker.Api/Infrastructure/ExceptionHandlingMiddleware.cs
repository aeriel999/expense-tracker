using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Api.Infrastructure;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next; _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException fv)
        {
            var errors = fv.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

            await WriteProblem(context, new ValidationFailedException(errors));
        }
        catch (DbUpdateException dbEx)
        {
            _logger.LogError(dbEx, "Persistence error");
            await WriteProblem(context, new PersistenceException("Database update failed.", dbEx));
        }
        catch (AppException appEx)
        {
            // наші доменні/бізнес помилки
            _logger.LogWarning(appEx, "Handled AppException {Code}", appEx.Code);
            await WriteProblem(context, appEx);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");
            var unknown = new AppUnknownException(ex); // невеликий внутр. клас нижче
            await WriteProblem(context, unknown);
        }
    }

    private sealed class AppUnknownException : AppException
    {
        public AppUnknownException(Exception inner)
            : base("unknown.error", (int)HttpStatusCode.InternalServerError, "Unexpected error occurred.", null, inner) { }
    }

    private static async Task WriteProblem(HttpContext ctx, AppException ex)
    {
        ctx.Response.ContentType = "application/problem+json";
        ctx.Response.StatusCode = ex.Status;

        var problem = new
        {
            type = $"https://errors/expensetracker/{ex.Code}",
            title = ex.Message,
            status = ex.Status,
            code = ex.Code,
            details = ex.Details,
            traceId = ctx.TraceIdentifier
        };

        await ctx.Response.WriteAsync(JsonSerializer.Serialize(problem));
    }
}
