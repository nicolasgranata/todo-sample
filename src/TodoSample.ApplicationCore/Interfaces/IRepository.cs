using System;
using System.Collections.Generic;
using System.Text;

namespace TodoSample.ApplicationCore.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> Get();

        TEntity Get<TKey>(TKey id) where TKey : IComparable, IFormattable;

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
