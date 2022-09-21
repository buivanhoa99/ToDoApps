using Microsoft.EntityFrameworkCore;
using ToDoApps.Core.Abstract.Repositories;
using ToDoApps.Core.Context;
using ToDoApps.Core.Entities;

namespace ToDoApps.Infrastructure.Repositories
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly ToDoAppsContext _context;
        private readonly DbSet<ToDoTask> _dbSet;

        public ToDoTaskRepository(ToDoAppsContext context)
        {
            _context = context;
            _dbSet = _context.Set<ToDoTask>();
        }

        public void DeleteById(int taskId)
        {
            var task = _dbSet.Find(taskId);
            DeleteByTask(task);
        }

        public void DeleteByTask(ToDoTask task)
        {
            _dbSet.Remove(task);
        }

        public Task<List<ToDoTask>> GetAllTasks()
        {
            return _dbSet.ToListAsync();
        }

        public Task<ToDoTask> GetById(int taskId)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id == taskId);
        }

        public async Task Insert(ToDoTask task)
        {
            await _dbSet.AddAsync(task);
        }

        public void UpdateTask(ToDoTask taskToUpdate)
        {
            _dbSet.Update(taskToUpdate);
        }
    }
}
