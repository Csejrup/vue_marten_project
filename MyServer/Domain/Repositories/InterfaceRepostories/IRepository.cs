namespace Domain.Repositories;

public interface IRepository<T>
{
    Task<T> GetByIdAsync(Guid id);
    Task SaveAsync(T aggregate);
}
