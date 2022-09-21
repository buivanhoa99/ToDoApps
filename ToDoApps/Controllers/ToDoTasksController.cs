using Microsoft.AspNetCore.Mvc;
using ToDoApps.Core.Abstract.Services;
using ToDoApps.Core.Models.DTOs;

namespace ToDoApps.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoTasksController : ControllerBase
    {
        private readonly IToDoTaskService _toDoTaskService;

        public ToDoTasksController(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _toDoTaskService.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTaskAsync(string taskName)
        {
            await _toDoTaskService.CreateTaskAsync(taskName);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTaskById(int taskId)
        {
            _toDoTaskService.DeleteTaskById(taskId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _toDoTaskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(int id, [FromBody] UpdateTaskDTO updateTask)
        {
            updateTask.Id = id;
            var task = await _toDoTaskService.UpdateTask(updateTask);
            return Ok(task);
        }
    }
}
