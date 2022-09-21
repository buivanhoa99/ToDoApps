using ToDoApps.Core.Models.DTOs;

namespace ToDoApps.Core.Abstract.Services
{
    public interface IToDoTaskService
    {
        public Task<ToDoTaskDTO> GetTaskById(int taskId);

        public Task DeleteTaskById(int taskId);

        public Task CreateTaskAsync(string taskName);

        public Task<ToDoTaskDTO> UpdateTask(UpdateTaskDTO taskToUpdate);

        public Task<List<ToDoTaskDTO>> GetAllTasks();
    }
}
