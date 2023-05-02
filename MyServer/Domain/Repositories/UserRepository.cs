using Domain.Aggregates.Users;
using Marten;

namespace Domain.Repositories;

public class UserRepository : IUserRepository
{
    // Marten document session for persisting and loading aggregates
    private readonly IDocumentSession _session;

    // Constructor that takes the Marten document session as a dependency
    public UserRepository(IDocumentSession session)
    {
        _session = session;
    }

    // Load a User aggregate by its ID using event sourcing
    public Task<User> GetByIdAsync(Guid id)
    {
        return _session.Events.AggregateStreamAsync<User>(id);
    }

    // Save a User aggregate by appending its uncommitted events to the event store
    public async Task SaveAsync(User user)
    {
        _session.Events.Append(user.Id, user.GetUncommittedEvents());
        await _session.SaveChangesAsync();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}