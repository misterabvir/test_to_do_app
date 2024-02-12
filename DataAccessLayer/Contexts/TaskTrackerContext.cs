using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccessLayer.Contexts
{
    public class TaskTrackerContext : DbContext
    {
        public DbSet<TaskEntity> Problems { get; set; }
        public DbSet<StatusEntity> States{ get; set; }
        
        public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
