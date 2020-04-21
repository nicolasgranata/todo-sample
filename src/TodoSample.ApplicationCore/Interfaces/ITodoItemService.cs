using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoSample.ApplicationCore.Entities;

namespace TodoSample.ApplicationCore.Services.Interfaces
{
    public interface ITodoItemService
    {
        Task<TodoItem> CreateAsync(TodoItem todoItem);
        TodoItem Create(TodoItem todoItem);
        TodoItem Get(int id);
        Task UpdateAsync(TodoItem todoItem);
        void Update(TodoItem todoItem);
        Task DeleteAsync(int id);
        void Delete(int id);
        IEnumerable<TodoItem> Get();
    }
}
