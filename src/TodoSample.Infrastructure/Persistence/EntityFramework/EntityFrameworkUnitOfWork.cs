using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoSample.Application.Interfaces;

namespace TodoSample.Infrastructure.Persistence.EntityFramework
{
    public class EntityFrameworkUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _dbContext;

        public EntityFrameworkUnitOfWork(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
