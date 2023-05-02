namespace Domain.Aggregates.Tasks;

// MyDomain/Events/TaskCreated.cs
public class TaskCreated
{
    public TaskCreated(Guid id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
