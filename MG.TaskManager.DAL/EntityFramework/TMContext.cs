using MG.TaskManager.DAL.Entity;
using System.Data.Entity;

namespace MG.TaskManager.DAL.EntityFramework
{
    public sealed class TMContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public TMContext() : base("DBConnection")
        {
            Database.Initialize(true);
        }
    }
}
