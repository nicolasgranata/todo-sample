using System.Collections.Generic;
using System.Threading.Tasks;
using TodoSample.ApplicationCore.Entities;
using TodoSample.ApplicationCore.Models;

namespace TodoSample.ApplicationCore.Services.Interfaces
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
