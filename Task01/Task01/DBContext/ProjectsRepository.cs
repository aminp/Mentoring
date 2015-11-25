using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Task01.DBContext
{
    public class ProjectsRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Shared contex
        /// </summary>
        internal ProjectsContext context;

        /// <summary>
        /// DbSet 
        /// </summary>
        internal DbSet<TEntity> dbSet;

        /// <summary>
        /// Constractor
        /// </summary>
        public ProjectsRepository(ProjectsContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Get item by ID
        /// </summary>
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Add new item by entity object
        /// </summary>
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Remove item by ID
        /// </summary>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Remove item by entity object
        /// </summary>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Edit item by entity object
        /// </summary>
        public virtual void Edit(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}