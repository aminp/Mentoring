namespace Task01.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Task01.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Task01.Security.ProjectsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Task01.Security.ProjectsContext context)
        {
            bool hasNewRow;

            if (context.Projects.Count() == 0)
            {
                hasNewRow = true;
                new List<Project>
                {
                    new Project{ProjectTitle="IPLN", ProjectManager="Anatoli",StartDate=DateTime.Parse("2015/04/09")},
                    new Project{ProjectTitle="Mentoring", ProjectManager="Dmitry",ProjectStatus=Status.Started,StartDate=DateTime.Parse("2015/11/01")}
                }.ForEach(p => context.Projects.AddOrUpdate(p));
            }

            if (context.Roles.Count() == 0)
            {
                hasNewRow = true;
                Role role1 = new Role { RoleName = "Admin" };
                Role role2 = new Role { RoleName = "User" };
                if (context.Users.Count() == 0)
                {
                    User user1 = new User { Username = "admin", Email = "admin@ymail.com", FirstName = "Admin", Password = "123456", IsActive = true, CreateDate = DateTime.UtcNow, Roles = new List<Role>() };
                    User user2 = new User { Username = "user1", Email = "user1@ymail.com", FirstName = "User1", Password = "123456", IsActive = true, CreateDate = DateTime.UtcNow, Roles = new List<Role>() };
                    user1.Roles.Add(role1);
                    user2.Roles.Add(role2);
                    context.Users.AddOrUpdate(user1);
                    context.Users.AddOrUpdate(user2);
                }
            }
            context.SaveChanges();
        }
    }
}
