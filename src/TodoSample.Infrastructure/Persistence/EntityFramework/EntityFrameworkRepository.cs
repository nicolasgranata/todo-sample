﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoSample.Application.Interfaces;
using TodoSample.Domain.Common;

namespace TodoSample.Infrastructure.Persistence.EntityFramework
{
    public abstract class EntityFrameworkRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : Entity where TContext : DbContext
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

        public TEntity Get(long id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public TEntity Add(TEntity entity)
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
