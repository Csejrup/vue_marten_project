using Domain.Aggregates.Users;

namespace Application.Services.ServiceInterfaces;

public interface IUserService
{
    Task<User> RegisterUserAsync(string name, string email);
    Task UpdateUserAsync(Guid id, string name, string email);

    Task<User> GetUserByIdAsync(Guid id);
    Task<IReadOnlyList<User>> GetAllAsync();

}