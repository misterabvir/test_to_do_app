using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessLayer.Contexts
{
    public class TaskTrackerContextDesignFactory : IDesignTimeDbContextFactory<TaskTrackerContext>
    {
        public TaskTrackerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskTrackerContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=task_tracker_db;Username=postgres;Password=password");
            return new TaskTrackerContext(optionsBuilder.Options);
        }
    }
}
