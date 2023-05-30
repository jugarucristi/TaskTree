using TaskTree.Application.Interfaces;
using TaskTree.Application.Models;

namespace TaskTree.Infrastructure.Retrievers;

public class TaskRetriever : ITaskRetriever
{
    public HashSet<TaskModel> Tasks { get; } = new();

    public HashSet<Step> Steps { get; } = new();


    public TaskRetriever()
    {
        this.initializeTask("First Task", "Cristi");
        this.initializeTask("Second Task", "Marius");
    }

    private void initializeTask(string taskName, string creatorName)
    {
        var firstTask = new TaskModel()
        {
            TaskName = taskName,
            CreatorName = creatorName,
        };

        Tasks.Add(firstTask);

        var firstStep = new Step()
        {
            ParentId = firstTask.Id,
            StepName = "First Step",
            CreatorName = creatorName,
        };

        Steps.Add(firstStep);

        var secondStep = new Step()
        {
            ParentId = firstStep.Id,
            StepName = "Second Step",
            CreatorName = creatorName,
        };

        Steps.Add(secondStep);

        var thirdStep = new Step()
        {
            ParentId = secondStep.Id,
            StepName = "Third Step",
            CreatorName = creatorName,
        };

        Steps.Add(thirdStep);

    }

    public async Task<List<TaskModel>> GetTasksAsync()
    {
        await Task.Delay(2000);

        return this.Tasks.ToList();
    }

    public async Task<List<Step>> GetStepsByParentIdAsync(string parentId)
    {
        await Task.Delay(2000);

        var result = Steps.Where(x => x.ParentId.ToString() == parentId);

        return result.ToList();
    }
}
