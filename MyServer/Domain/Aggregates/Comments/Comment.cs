using Domain.Base;

namespace Domain.Aggregates.Comments;

public class Comment : BaseAggregate
{
    public Guid UserId { get; private set; }
    public Guid TaskId { get; private set; }
    public string? Content { get; private set; }
    public bool IsDeleted { get; private set; }

    public Comment(CommentCreated @event)
    {
        Apply(@event);
    }

    public void Update(string content)
    {
        var @event = new CommentUpdated { Id = Id, Content = content };
        RaiseEvent(@event);
        Apply(@event);
    }


    public void Apply(CommentCreated @event)
    {
        Id = @event.Id;
        UserId = @event.UserId;
        TaskId = @event.TaskId;
        Content = @event.Content;
        IsDeleted = false;
    }

    public void Update(CommentUpdated @event)
    {
        Apply(@event);
    }

    public void Apply(CommentUpdated @event)
    {
        Content = @event.Content;
    }

    public void Delete(CommentDeleted @event)
    {
        Apply(@event);
    }
    public void Delete()
    {
        var @event = new CommentDeleted { Id = Id };
        RaiseEvent(@event);
        Apply(@event);
    }
    public void Apply(CommentDeleted @event)
    {
        IsDeleted = true;
    }
}