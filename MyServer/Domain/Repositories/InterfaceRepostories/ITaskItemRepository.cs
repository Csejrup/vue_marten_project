using Domain.Aggregates.Tasks;

namespace Domain.Repositories.InterfaceRepostories;

public interface ITaskItemRepository
{
    Task<TaskItem?> GetByIdAsync(Guid id);
    Task SaveAsync(TaskItem taskItem);
}
