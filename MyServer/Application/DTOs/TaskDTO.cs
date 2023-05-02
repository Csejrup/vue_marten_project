using Domain.Enums;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Domain.Entities;
/*
 * Task: This DTO represents a task in the system.
 * It contains attributes such as the task's title, description, status
 * (e.g., pending, in progress, completed), creation date, due date,
 * priority, and any associated labels/tags.
 * It may also include a reference to the user assigned to the task.
 */
public sealed class TaskDto
{
    public TaskDto(string title, string description, string labels)
    {
        Title = title;
        Description = description;
        Labels = labels;
    }

    public string Title { get; init; }
    public string Description { get; init; }
    public TaskStatus Status { get; init; }
    public DateTime CreationDate { get; init; }
    public DateTime DueDate { get; init; }
    public TaskPriority Priority { get; init; }
    public string Labels { get; init; }
}