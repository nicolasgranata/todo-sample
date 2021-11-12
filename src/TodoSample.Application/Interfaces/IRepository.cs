using System.Collections.Generic;
using TodoSample.Domain.Common;

namespace TodoSample.Application.Interfaces
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
