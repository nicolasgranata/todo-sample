using TodoSample.ApplicationCore.Entities;
using TodoSample.Infrastructure.Data.EntityFramework;

namespace TodoSample.Infrastructure.Data.Repositories
{
    public class TodoItemRepository : EntityFrameworkRepository<TodoItem, TodoSampleDbContext>
    {
        public TodoItemRepository(TodoSampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
