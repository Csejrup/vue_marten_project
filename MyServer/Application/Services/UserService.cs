using Application.Services.ServiceInterfaces;
using Domain.Aggregates.Users;
using Domain.Repositories;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> RegisterUserAsync(string name, string email)
    {
     //   var registerUserEvent = new User(Guid.NewGuid(), name, email);
      //  var user = new User(taskCreatedEvent);
     //   await _userRepository.SaveAsync(taskItem);
      //  taskItem.ClearUncommittedEvents();
      //  user.RaiseEvent(new UserRegistered(Guid.NewGuid(), name, email));
      //  await _userRepository.SaveAsync(user);
        return null;
    }

    public async Task UpdateUserAsync(Guid id, string name, string email)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user != null)
        {
            user.RaiseEvent(new UserUpdated(id, name, email));
            await _userRepository.SaveAsync(user);
        }
    }

    public Task<User> GetUserByIdAsync(Guid id)
    {
        return _userRepository.GetByIdAsync(id);
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        return _userRepository.GetAllAsync();
    }
}