using Domain.Aggregates.Tasks;
using Marten;

namespace Domain.Repositories;

public class TaskItemRepository : ITaskItemRepository
{
    // Marten document session for persisting and loading aggregates
    private readonly IDocumentSession _session;

    // Constructor that takes the Marten document session as a dependency
    public TaskItemRepository(IDocumentSession session)
    {
        _session = session;
    }

    // Load a TaskItem aggregate by its ID using event sourcing
    public Task<TaskItem> GetByIdAsync(Guid id)
    {
        return _session.Events.AggregateStreamAsync<TaskItem>(id);
    }

    // Save a TaskItem aggregate by appending its uncommitted events to the event store
    public async Task SaveAsync(TaskItem taskItem)
    {
        _session.Events.Append(taskItem.Id, taskItem.GetUncommittedEvents());
        await _session.SaveChangesAsync();
    }
}