namespace Task01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        DeveloperCount = c.Int(nullable: false),
                        ProjectTitle = c.String(),
                        ProjectManager = c.String(),
                        StartDate = c.DateTime(),
                        FinishedDate = c.DateTime(),
                        ProjectStatus = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projects");
        }
    }
}
