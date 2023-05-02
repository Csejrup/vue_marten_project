using Domain.Aggregates.Tasks;

namespace Application.Services.ServiceInterfaces;

public interface ITaskItemService
{   
    Task<TaskItem> CreateTaskAsync(string title, string description);

    Task<TaskItem> GetTaskItemByIdAsync(Guid id);
    Task UpdateTaskAsync(Guid id, string title, string description);
    // Add other methods for task-related use cases...
}