using System;
using System.Collections.Generic;
using System.Data.Entity;
using Task01.Models;

namespace Task01.DBContext
{
    public class ProjectsDataInitializer : CreateDatabaseIfNotExists<ProjectsContext>
    {
        public ProjectsDataInitializer(){}
        protected override void Seed(ProjectsContext context)
        {
            #region New Projects
                new List<Project>
                {
                new Project{ProjectTitle="IPLN", ProjectManager="Anatoli",ProjectStatus=Status.Started,StartDate=DateTime.Parse("2015/04/09")},
                new Project{ProjectTitle="Mentoring", ProjectManager="Dmitry",ProjectStatus=Status.Started,StartDate=DateTime.Parse("2015/11/01")}
                }.ForEach(p => context.Projects.Add(p));
            #endregion
            
            context.SaveChanges();

            base.Seed(context);
        }
    }
}