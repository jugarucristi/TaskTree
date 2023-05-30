using TaskTree.Application.Interfaces;
using TaskTree.Application.Models;

namespace TaskTree.Infrastructure.Retrievers;

public class TaskRetriever : ITaskRetriever
{
    public HashSet<TaskModel> Tasks { get; } = new();


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

        var firstStep = new TaskModel()
        {
            ParentId = firstTask.Id,
            TaskName = "First Step",
            CreatorName = creatorName,
        };

        Tasks.Add(firstStep);

        var secondStep = new TaskModel()
        {
            ParentId = firstStep.Id,
            TaskName = "Second Step",
            CreatorName = creatorName,
        };

        Tasks.Add(secondStep);

        var thirdStep = new TaskModel()
        {
            ParentId = secondStep.Id,
            TaskName = "Third Step",
            CreatorName = creatorName,
        };

        Tasks.Add(thirdStep);

    }

    public async Task<List<TaskModel>> GetTasksAsync()
    {
        await Task.Delay(2000);

        var result = Tasks.Where(x => x.ParentId == null).ToList();

        return result;
    }

    public async Task<List<TaskModel>> GetStepsByParentIdAsync(string parentId)
    {
        await Task.Delay(2000);

        var result = Tasks.Where(x => x.ParentId.ToString() == parentId);

        return result.ToList();
    }
}
