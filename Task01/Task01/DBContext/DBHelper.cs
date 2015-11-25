using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task01.Models;

namespace Task01.DBContext
{
    public class DBHelper : IDisposable
    {
        private ProjectsContext context = new ProjectsContext();

        #region Properties
        public ProjectsRepository<Project> Projects
        {
            get
            {
                if (this._project == null)
                    this._project = new ProjectsRepository<Project>(context);

                return this._project;
            }
        }
        private ProjectsRepository<Project> _project;

        #endregion

        #region IDisposable implementation
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    context.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public void Save()
        {
            context.SaveChanges();
        }
    }
}