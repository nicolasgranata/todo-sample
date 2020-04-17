using System.Collections.Generic;
using System.Threading.Tasks;
using TodoSample.ApplicationCore.Entities;
using TodoSample.ApplicationCore.Interfaces;
using TodoSample.ApplicationCore.Services.Interfaces;

namespace TodoSample.ApplicationCore.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly IRepository<TodoItem> _todoItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TodoItemService(IRepository<TodoItem> todoItemRepository, IUnitOfWork unitOfWork)
        {
            _todoItemRepository = todoItemRepository;
            _unitOfWork = unitOfWork;
        }

        public TodoItem Create(TodoItem todoItem)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TodoItem> CreateAsync(TodoItem todoItem)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public TodoItem Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TodoItem> Get()
        {
            throw new System.NotImplementedException();
        }

        public void Update(TodoItem todoItem)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(TodoItem todoItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
