using System.Collections.Generic;
using TodoSample.ApplicationCore.Entities;

namespace TodoSample.ApplicationCore.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> Get();

        TEntity Get(long id);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
