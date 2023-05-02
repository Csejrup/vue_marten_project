using Domain.Base;

namespace Domain.Aggregates.Tasks;

// MyDomain/Aggregates/TaskItem.cs
public class TaskItem : BaseAggregate
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool IsComplete { get; private set; }

    public TaskItem(TaskCreated @event)
    {
        Apply(@event);
    }

    public void Update(string title, string description)
    {
        var @event = new TaskUpdated { Id = Id, Title = title, Description = description };
        RaiseEvent(@event);
        Apply(@event);
    }

    public void Apply(TaskCreated @event)
    {
        Id = @event.Id;
        Title = @event.Title;
        Description = @event.Description;
        IsComplete = false;
    }

    public void Update(TaskUpdated @event)
    {
        Apply(@event);
    }

    public void Apply(TaskUpdated @event)
    {
        Title = @event.Title;
        Description = @event.Description;
    }

    public void Complete(TaskDeleted @event)
    {
        Apply(@event);
    }

    public void Apply(TaskDeleted @event)
    {
        IsComplete = true;
    }
}
