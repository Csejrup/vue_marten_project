using Domain.Aggregates.Comments;
using Marten;

namespace Domain.Repositories;

public class CommentRepository : ICommentRepository
{
    // Marten document session for persisting and loading aggregates
    private readonly IDocumentSession _session;

    // Constructor that takes the Marten document session as a dependency
    public CommentRepository(IDocumentSession session)
    {
        _session = session;
    }

    // Load a Comment aggregate by its ID using event sourcing
    public Task<Comment> GetByIdAsync(Guid id)
    {
        return _session.Events.AggregateStreamAsync<Comment>(id);
    }

    // Save a Comment aggregate by appending its uncommitted events to the event store
    public async Task SaveAsync(Comment comment)
    {
        _session.Events.Append(comment.Id, comment.GetUncommittedEvents());
        await _session.SaveChangesAsync();
    }

    public Task<IEnumerable<Comment>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}