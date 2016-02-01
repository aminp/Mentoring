using System;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Task01.Security
{
    interface IProjectsRepository<TEntity> : IDisposable
        where TEntity:class
    {
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Edit(TEntity entityToUpdate);
        void Save();
        Expression<Func<T, bool>> CreateTextSearch<T>(string searchText);
    }
}
