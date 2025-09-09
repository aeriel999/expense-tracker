/// <summary>
/// Базовий виняток застосунку.
/// Містить машиночитний <see cref="Code"/>, HTTP-статус у вигляді int (<see cref="Status"/>),
/// та довільні <see cref="Details"/> для повернення у тіло відповіді.
/// </summary>
/// <param name="code">Короткий код помилки (напр., "category_income.not_found").</param>
/// <param name="status">
/// HTTP статус як число (наприклад: 400, 404, 409, 422, 500).
/// Залишаємо тип int, як у твоєму варіанті.
/// </param>
/// <param name="message">Людиночитне повідомлення для клієнта.</param>
/// <param name="details">Будь-які додаткові дані (словник помилок валідації тощо).</param>
/// <param name="inner">Внутрішній виняток для діагностики (логів).</param>
public abstract class AppException(
    string code, int status, string message, object? details = null, Exception? inner = null)
    : Exception(message, inner)
{
    /// <summary>HTTP статус як число (наприклад, 404 для Not Found).</summary>
    public int Status { get; } = status;

    /// <summary>Машиночитний код помилки (стабільний для клієнта).</summary>
    public string Code { get; } = code;

    /// <summary>Додаткові деталі (наприклад, помилки валідації по полях).</summary>
    public object? Details { get; } = details;
}

/// <summary>
/// 404 Not Found для будь-якої сутності.
/// Приклад: new NotFoundException("CategoryItem", id)
/// дасть code: "categoryitem.not_found" і повідомлення з ключем.
/// </summary>
public sealed class NotFoundException : AppException
{
    public NotFoundException(string entity, object? key = null)
        : base($"{entity.ToLowerInvariant()}.not_found", 404,
            key is null ? $"{entity} not found." : $"{entity} with key '{key}' not found.")
    { }
}

/// <summary>
/// 409 Conflict (наприклад, дублікат імені або concurrency-конфлікт).
/// Використовуй власний код на кшталт "category_income.duplicate_name".
/// </summary>
public sealed class ConflictException : AppException
{
    public ConflictException(string code, string message, object? details = null)
        : base(code, 409, message, details) { }
}

/// <summary>
/// 400 Bad Request для порушення бізнес-правил (не валідатор, а саме доменна логіка).
/// Напр., "amount.must_be_positive".
/// </summary>
public sealed class DomainRuleViolationException : AppException
{
    public DomainRuleViolationException(string code, string message, object? details = null)
        : base(code, 400, message, details) { }
}

/// <summary>
/// 422 Unprocessable Entity для помилок FluentValidation/DataAnnotations.
/// У <c>errors</c> зазвичай передаємо словник: property -> масив повідомлень.
/// </summary>
public sealed class ValidationFailedException : AppException
{
    public ValidationFailedException(object errors)
        : base("validation.failed", 422, "Validation failed.", errors) { }
}

/// <summary>
/// 500 Internal Server Error для помилок персистенції/БД/інфраструктури.
/// Обгортай оригінальний виняток у <paramref name="inner"/>.
/// </summary>
public sealed class PersistenceException : AppException
{
    public PersistenceException(string message, Exception inner)
        : base("persistence.error", 500, message, null, inner) { }
}
