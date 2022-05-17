using MG.TaskManager.DAL.Entity;
using System.Data.Entity;

namespace MG.TaskManager.DAL.EntityFramework
{
    public sealed class TMContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        static TMContext()
        {
            Database.SetInitializer<TMContext>(new DBInitializer());
        }

        public TMContext() : base("DBConnection")
        {
            //Database.Initialize(true);
        }
    }

    public class DBInitializer : DropCreateDatabaseIfModelChanges<TMContext> {}
}
