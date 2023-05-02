namespace Domain.Aggregates.Comments;

public class CommentCreated
{
    public CommentCreated( Guid taskId, string? content)
    {
       // UserId = userId;
        TaskId = taskId;
        Content = content;
    }

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
    public string? Content { get; set; }
}