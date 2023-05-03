using Application.Services.ServiceInterfaces;
using Domain.Aggregates.Tasks;
using Domain.Repositories;
using Domain.Repositories.InterfaceRepostories;

namespace Application.Services;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _taskItemRepository;

    public TaskItemService(ITaskItemRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
    }

    public async Task<TaskItem> GetTaskItemByIdAsync(Guid id)
    {
        return await _taskItemRepository.GetByIdAsync(id);

    }
    // Implement the methods from ITaskItemService...
    public async Task<TaskItem> CreateTaskAsync(string title, string description)
    {
        var taskCreatedEvent = new TaskCreated(Guid.NewGuid(), title, description);
        var taskItem = new TaskItem(taskCreatedEvent);
        await _taskItemRepository.SaveAsync(taskItem);
        taskItem.ClearUncommittedEvents();
        return taskItem;
    }

    public async Task UpdateTaskAsync(Guid id, string title, string description)
    {
        var taskItem = await _taskItemRepository.GetByIdAsync(id);
        taskItem!.Update(title, description);
        await _taskItemRepository.SaveAsync(taskItem);
        taskItem.ClearUncommittedEvents();
    }
}