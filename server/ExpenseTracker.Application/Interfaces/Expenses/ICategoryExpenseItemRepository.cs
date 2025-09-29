namespace ExpenseTracker.Application.Interfaces.Expenses;


public interface ICategoryExpenseItemRepository
{
    Task<bool> ExistsByIdAsync(Guid id, CancellationToken ct = default);

    Task<Guid> GetCategoryIdByCategoryItemIdAsync(Guid id, CancellationToken ct = default);
}
