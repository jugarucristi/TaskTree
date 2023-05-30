using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaskTree.Application.Interfaces;

namespace TaskTree.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;
        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasksAsync()
        {
            var result = await taskService.GetTasksAsync();

            return Ok(JsonSerializer.Serialize(result));
        }

        [HttpGet("{stepId}")]
        public async Task<IActionResult> GetStepsByParentIdAsync([FromRoute] string stepId)
        {
            var result = await taskService.GetStepsByParentIdAsync(stepId);

            return Ok(JsonSerializer.Serialize(result));
        }
    }
}