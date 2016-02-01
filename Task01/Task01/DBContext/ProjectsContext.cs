using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Task01.Models;

namespace Task01.Security
{
    public class ProjectsContext : DbContext
    {
        public ProjectsContext(): base("ProjectsCnstr"){}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .Map(m =>
            {
                m.ToTable("UserRoles");
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleId");
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}