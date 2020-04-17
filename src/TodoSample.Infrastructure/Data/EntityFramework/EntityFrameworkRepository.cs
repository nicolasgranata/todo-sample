using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoSample.ApplicationCore.Interfaces;

namespace TodoSample.Infrastructure.Data.EntityFramework
{
    public abstract class EntityFrameworkRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class, IEntity where TContext : DbContext
    {
        protected TContext _dbContext { get; private set; }

        public EntityFrameworkRepository(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>();
        }

        public TEntity Get<TKey>(TKey id) where TKey : IComparable, IFormattable
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public TEntity Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
