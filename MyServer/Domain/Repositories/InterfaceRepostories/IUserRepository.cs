using Domain.Aggregates.Users;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task SaveAsync(User user);
    
    Task<IEnumerable<User>> GetAllAsync();

}