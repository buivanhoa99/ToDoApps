using ToDoApps.Core.Abstract.Repositories;
using ToDoApps.Core.Abstract.Services;
using ToDoApps.Core.Entities;
using ToDoApps.Core.Models.DTOs;

namespace ToDoApps.Infrastructure.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ToDoTaskService(IToDoTaskRepository toDoTaskRepository, IUnitOfWork unitOfWork)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateTaskAsync(string taskName)
        {
            var task = new ToDoTask
            {
                Name = taskName,
            };
            await _toDoTaskRepository.Insert(task);
            await _unitOfWork.SaveChanges();

        }

        public async Task DeleteTaskById(int taskId)
        {
            _toDoTaskRepository.DeleteById(taskId);
            await _unitOfWork.SaveChanges();
        }

        public async Task<List<ToDoTaskDTO>> GetAllTasks()
        {
            var tasks = await _toDoTaskRepository.GetAllTasks();
            return tasks.Select(x => new ToDoTaskDTO
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                IsActive = x.IsActive
            }).ToList();
        }

        public async Task<ToDoTaskDTO> GetTaskById(int taskId)
        {
            var task = await _toDoTaskRepository.GetById(taskId);
            return new ToDoTaskDTO
            {
                Id = task.Id,
                Name = task.Name,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt,
                IsActive = task.IsActive
            };
        }

        public async Task<ToDoTaskDTO> UpdateTask(UpdateTaskDTO taskToUpdate)
        {
            var task = await _toDoTaskRepository.GetById(taskToUpdate.Id);
            task.Name = taskToUpdate.Name;
            task.IsActive = taskToUpdate.IsActive;
            task.UpdatedAt = DateTime.Now;

            _toDoTaskRepository.UpdateTask(task);
            await _unitOfWork.SaveChanges();
            return new ToDoTaskDTO
            {
                Id = task.Id,
                Name = task.Name,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt,
                IsActive = task.IsActive,
            };
        }
    }
}
