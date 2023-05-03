using Domain.Aggregates.Users;

namespace Domain.Repositories.InterfaceRepostories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task SaveAsync(User user);
    
    Task<IReadOnlyList<User>> GetAllAsync();

}