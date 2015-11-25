using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Task01.Models;

namespace Task01.DBContext
{
    public class ProjectsContext : DbContext
    {
        public ProjectsContext(): base("ProjectsCnstr")
        {}

        public DbSet<Project> Projects { get; set; }
    }
}