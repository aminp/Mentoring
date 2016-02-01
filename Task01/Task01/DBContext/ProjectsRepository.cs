using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Task01.Security
{
    public class ProjectsRepository<TEntity> : IProjectsRepository<TEntity>
        where TEntity : class
    {

        private bool disposed = false;

        internal ProjectsContext context;

        internal DbSet<TEntity> dbSet;

        public ProjectsRepository(ProjectsContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }


        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }


        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }


        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }


        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }


        public virtual void Edit(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }


        public Expression<Func<T, bool>> CreateTextSearch<T>(string searchText)
        {
            Type t = typeof(T);
            var props = t.GetProperties().Cast<PropertyInfo>().Where(p => p.PropertyType == typeof(string));

            var searchTextExpr = Expression.Constant(searchText);
            var tParameterExpr = Expression.Parameter(typeof(T));

            Expression expr = null;
            foreach (var prop in props)
            {
                var criteria = Expression.Call(
                    Expression.Property(tParameterExpr, prop),
                    typeof(string).GetMethod("Contains", new Type[] { typeof(string) }),
                    searchTextExpr);
                if (expr == null)
                    expr = criteria;
                else
                    expr = Expression.Or(expr, criteria);
            }
            return Expression.Lambda<Func<T, bool>>(expr, tParameterExpr);
        }
    }
}