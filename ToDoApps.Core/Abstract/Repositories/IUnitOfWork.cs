namespace ToDoApps.Core.Abstract.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}
