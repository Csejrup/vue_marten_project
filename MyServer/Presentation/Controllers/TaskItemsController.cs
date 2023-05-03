using Application.Services.ServiceInterfaces;
using Domain.Aggregates.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TaskItemsController : ControllerBase
{
    private readonly ITaskItemService _taskItemService;

    public TaskItemsController(ITaskItemService taskItemService)
    {
        _taskItemService = taskItemService;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetTaskItem(Guid id)
    {
        var taskItem = await _taskItemService.GetTaskItemByIdAsync(id);
        if (taskItem == null)
        {
            throw new Exception("TaskItem [");
        }

        return Ok(taskItem);
    }

    [HttpPost]
    public async Task<ActionResult<TaskItem>> CreateTaskItem([FromBody] TaskItemCreateModel taskItemCreateModel)
    {
        var taskItem = await _taskItemService.CreateTaskAsync(taskItemCreateModel.Title, taskItemCreateModel.Description);
        return CreatedAtAction(nameof(GetTaskItem), new { id = taskItem.Id }, taskItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTaskItem([FromBody] TaskItemCreateModel taskItemCreateModel)
    {
        await _taskItemService.UpdateTaskAsync(taskItemCreateModel.Id, taskItemCreateModel.Title, taskItemCreateModel.Description);
        return NoContent();
    }
    
}

public class TaskItemCreateModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid Id { get; private set; }

}