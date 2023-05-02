using Domain.Aggregates.Comments;

namespace Domain.Repositories;

public interface ICommentRepository
{
    Task<Comment?> GetByIdAsync(Guid id);
    Task SaveAsync(Comment comment);
    Task<IEnumerable<Comment>> GetAllAsync();
}