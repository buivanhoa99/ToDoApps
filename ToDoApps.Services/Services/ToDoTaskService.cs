using Microsoft.EntityFrameworkCore;
using ToDoApps.Core.Abstract.Services;
using ToDoApps.Core.Context;
using ToDoApps.Core.Entities;
using ToDoApps.Core.Models.DTOs;

namespace ToDoApps.Services.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly ToDoAppsContext _context;
        private readonly DbSet<ToDoTask> dbSet;
        public ToDoTaskService(ToDoAppsContext context)
        {
            _context = context;
            dbSet = dbSet;
        }

        public async Task CreateTask(string taskName)
        {
            await dbSet.AddAsync(new ToDoTask
            {
                IsActive = false,
                Name = taskName
            });
        }

        public void DeleteTaskById(int taskId)
        {
            var task = dbSet.Find(taskId);
            if (task != null)
            {
                _context.Remove(task);
            }
        }

        public Task<List<ToDoTaskDTO>> GetAllTasks()
        {
            return dbSet.Select(x => new ToDoTaskDTO
            {
                Id = x.Id,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task<ToDoTaskDTO> GetTaskById(int taskId)
        {
            var task = await dbSet.FirstOrDefaultAsync(x => x.Id == taskId);
            if (task != null)
            {
                return new ToDoTaskDTO
                {
                    Id = task.Id,
                    Name = task.Name,
                    CreatedAt = task.CreatedAt,
                    UpdatedAt = task.UpdatedAt,
                    IsActive = task.IsActive,
                };
            }
            return null;
        }

        public Task<ToDoTaskDTO> UpdateTask(UpdateTaskDTO taskToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
