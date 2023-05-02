namespace Domain.Aggregates.Comments;

public class CommentDeleted
{
    public CommentDeleted()
    {
        
    }
    public CommentDeleted(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}