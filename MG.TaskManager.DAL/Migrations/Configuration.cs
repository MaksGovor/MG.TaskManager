namespace MG.TaskManager.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MG.TaskManager.DAL.EntityFramework.TMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MG.TaskManager.DAL.EntityFramework.TMContext";
        }

        protected override void Seed(MG.TaskManager.DAL.EntityFramework.TMContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
