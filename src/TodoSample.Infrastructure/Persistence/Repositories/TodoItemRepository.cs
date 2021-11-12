using TodoSample.Domain.Entities;
using TodoSample.Infrastructure.Persistence.EntityFramework;

namespace TodoSample.Infrastructure.Persistence.Repositories
{
    public class TodoItemRepository : EntityFrameworkRepository<TodoItem, TodoSampleDbContext>
    {
        public TodoItemRepository(TodoSampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
