using System.Text.Json.Serialization;

namespace Application.Base;

public abstract class AggregateBase
{
    // For indexing our event streams
    [JsonInclude]
    public Guid Id { get; protected set; }

    // For protecting the state, i.e. conflict prevention
    // The setter is only public for setting up test conditions
    [JsonInclude]
    public long Version { get; set; }

    // JsonIgnore - for making sure that it won't be stored in inline projection
    [JsonIgnore] private readonly List<object> _uncommittedEvents = new List<object>();

    // Get the deltas, i.e. events that make up the state, not yet persisted
    public IEnumerable<object> GetUncommittedEvents()
    {
        return _uncommittedEvents;
    }

    // Mark the deltas as persisted.
    public void ClearUncommittedEvents()
    {
        _uncommittedEvents.Clear();
    }

    protected void AddUncommittedEvent(object @event)
    {
        // add the event to the uncommitted list
        _uncommittedEvents.Add(@event);
    }   
}