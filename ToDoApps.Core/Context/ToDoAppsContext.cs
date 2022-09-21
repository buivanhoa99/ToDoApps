using Microsoft.EntityFrameworkCore;
using ToDoApps.Core.Entities;

namespace ToDoApps.Core.Context
{
    public class ToDoAppsContext : DbContext
    {
        public ToDoAppsContext(DbContextOptions<ToDoAppsContext> options) : base(options)
        {
        }

        public ToDoAppsContext() : base()
        {

        }

        public DbSet<ToDoTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoTask>().ToTable(nameof(ToDoTask));
        }
    }
}
