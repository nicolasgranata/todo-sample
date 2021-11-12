using System.Collections.Generic;
using System.Threading.Tasks;
using TodoSample.Domain.Entities;
using TodoSample.Domain.Models;

namespace TodoSample.Application.Interfaces
{
    public interface ITodoItemService
    {
        Task<TodoItem> CreateAsync(TodoItemCreate todoItemCreate);
        TodoItem Create(TodoItemCreate todoItemCreate);
        TodoItem Get(int id);
        Task UpdateAsync(TodoItemUpdate todoItemUpdate);
        void Update(TodoItemUpdate todoItemUpdate);
        Task DeleteAsync(int id);
        void Delete(int id);
        IEnumerable<TodoItem> Get();
    }
}
