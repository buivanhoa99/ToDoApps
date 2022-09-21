using ToDoApps.Core.Abstract.Repositories;
using ToDoApps.Core.Context;

namespace ToDoApps.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoAppsContext _context;

        public UnitOfWork(ToDoAppsContext context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
