using Microsoft.EntityFrameworkCore;
using TodoSample.ApplicationCore.Entities;

namespace TodoSample.Infrastructure.Data.EntityFramework
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
