using ToDoApps.Core.Entities;

namespace ToDoApps.Core.Abstract.Repositories
{
    public interface IToDoTaskRepository
    {
        public Task<ToDoTask> GetById(int taskId);

        public void DeleteById(int taskId);

        public void DeleteByTask(ToDoTask task);

        public Task Insert(ToDoTask task);

        public void UpdateTask(ToDoTask taskToUpdate);

        public Task<List<ToDoTask>> GetAllTasks();
    }
}
