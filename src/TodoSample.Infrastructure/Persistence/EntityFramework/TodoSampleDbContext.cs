using Microsoft.EntityFrameworkCore;
using TodoSample.Domain.Entities;

namespace TodoSample.Infrastructure.Persistence.EntityFramework
{
    public class TodoSampleDbContext : DbContext
    {
        public TodoSampleDbContext(DbContextOptions<TodoSampleDbContext> options)
            : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
