namespace TaskTree.Application.Models;

public class Step
{
    public Guid Id { get; } = Guid.NewGuid();

    public Guid ParentId { get; set; }

    public string StepName { get; set; }

    public string CreatorName { get; set; }
}
