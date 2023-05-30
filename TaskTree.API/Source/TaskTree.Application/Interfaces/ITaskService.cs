using TaskTree.Application.Models;

namespace TaskTree.Application.Interfaces;

public interface ITaskService
{
    public Task<List<TaskModel>> GetTasksAsync();

    public Task<List<Step>> GetStepsByParentIdAsync(string parentId);
}
