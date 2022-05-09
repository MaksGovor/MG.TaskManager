namespace MG.TaskManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        BeginDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        Description = c.String(),
                        Priority = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        ProjectId = c.Int(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Login = c.String(nullable: false),
                        PasswordHash = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "UserId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
        }
    }
}
