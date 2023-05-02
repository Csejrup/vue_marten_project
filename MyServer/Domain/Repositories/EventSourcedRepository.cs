namespace Domain.Repositories;
using Marten;

public class EventSourcedRepository<T> : IRepository<T> where T : class
{
    private readonly IDocumentStore _documentStore;

    public EventSourcedRepository(IDocumentStore documentStore)
    {
        _documentStore = documentStore;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        using var session = _documentStore.OpenSession();
        return await session.Events.AggregateStreamAsync<T>(id);
    }

    public async Task SaveAsync(T aggregate)
    {
        using var session = _documentStore.OpenSession();

        // Assuming the aggregate has a public 'Id' property
        var id = (Guid)typeof(T).GetProperty("Id")?.GetValue(aggregate);

        if (id == Guid.Empty)
        {
            throw new InvalidOperationException("Aggregate Id cannot be empty.");
        }

        session.Events.Append(id, aggregate);

        await session.SaveChangesAsync();
    }
}

