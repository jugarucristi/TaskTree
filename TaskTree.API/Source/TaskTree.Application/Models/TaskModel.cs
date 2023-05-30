namespace TaskTree.Application.Models;

public class TaskModel
{
    public Guid Id { get; } = Guid.NewGuid();

    public string TaskName { get; set; }

    public string CreatorName { get; set; }
}
