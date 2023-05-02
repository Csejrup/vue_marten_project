namespace Domain.Base;

public abstract class BaseAggregate
{
    public Guid Id { get; protected set; }
    private readonly List<object> _uncommittedEvents = new();

    public void RaiseEvent(object @event)
    {
        _uncommittedEvents.Add(@event);
    }

    public IReadOnlyList<object> GetUncommittedEvents()
    {
        return _uncommittedEvents.AsReadOnly();
    }

    public void ClearUncommittedEvents()
    {
        _uncommittedEvents.Clear();
    }
}
