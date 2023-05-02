namespace Domain.Aggregates.Comments;

public class CommentUpdated
{
    public CommentUpdated()
    {
        
    }
    public CommentUpdated(Guid id, string? content)
    {
        Id = id;
        Content = content;
    }

    public Guid Id { get; set; }
    public string? Content { get; set; }
}