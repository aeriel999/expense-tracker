namespace ExpenseTracker.Application.Interfaces.Categories;

public interface ICategoryRepository<T>
{
    Task<T?> GetByIdAsync(Guid id);

    Task<List<T>?> GetListAsync();

    Task<T?> AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(Guid id);
}
