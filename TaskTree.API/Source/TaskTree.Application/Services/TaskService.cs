using TaskTree.Application.Interfaces;
using TaskTree.Application.Models;

namespace TaskTree.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRetriever taskRetriever;

    public TaskService(ITaskRetriever taskRetriever)
    {
        this.taskRetriever = taskRetriever;
    }

    public async Task<List<TaskModel>> GetTasksAsync()
    {
        return await taskRetriever.GetTasksAsync();
    }

    public async Task<List<TaskModel>> GetStepsByParentIdAsync(string parentId)
    {
        return await taskRetriever.GetStepsByParentIdAsync(parentId);
    }
}
