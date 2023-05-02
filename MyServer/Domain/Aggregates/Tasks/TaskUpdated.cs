namespace Domain.Aggregates.Tasks;

public class TaskUpdated
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}