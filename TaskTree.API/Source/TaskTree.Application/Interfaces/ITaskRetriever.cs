﻿using TaskTree.Application.Models;

namespace TaskTree.Application.Interfaces;

public interface ITaskRetriever
{
    public Task<List<TaskModel>> GetTasksAsync();

    public Task<List<TaskModel>> GetStepsByParentIdAsync(string parentId);
}
