using Application.Services.ServiceInterfaces;
using Domain.Aggregates.Comments;
using Domain.Repositories;

namespace Application.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<Comment> CreateCommentAsync( string content)
    {
        var commentCreatedEvent = new CommentCreated(Guid.NewGuid(),content);
        var comment = new Comment(commentCreatedEvent);
        await _commentRepository.SaveAsync(comment);
        comment.ClearUncommittedEvents();
        return comment;
    }

    public async Task UpdateCommentAsync(Guid id, string content)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        var commentUpdatedEvent = new CommentUpdated(id, content);
        comment!.Apply(commentUpdatedEvent);
        await _commentRepository.SaveAsync(comment);
        comment.ClearUncommittedEvents();
    }

    public async Task DeleteCommentAsync(Guid id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        var commentDeletedEvent = new CommentDeleted(id);
        comment!.Apply(commentDeletedEvent);
        await _commentRepository.SaveAsync(comment);
        comment.ClearUncommittedEvents();
    }
    public async Task<Comment> GetCommentByIdAsync(Guid id)
    {
        return await _commentRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
    {
        return await _commentRepository.GetAllAsync();
    }
}