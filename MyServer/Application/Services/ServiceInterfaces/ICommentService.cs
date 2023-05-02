using Domain.Aggregates.Comments;

namespace Application.Services.ServiceInterfaces;

public interface ICommentService
{
    Task<Comment> CreateCommentAsync(string content);
    Task UpdateCommentAsync(Guid id, string content);
    Task DeleteCommentAsync(Guid id);

    Task<Comment> GetCommentByIdAsync(Guid id);

    Task<IEnumerable<Comment>> GetAllCommentsAsync();
    // Add other methods for comment-related use cases...
}