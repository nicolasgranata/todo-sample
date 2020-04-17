using System;
using System.Collections.Generic;
using System.Linq;
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
            var todoItemCreated = _todoItemRepository.Add(todoItem);
            _unitOfWork.Save();

            return todoItemCreated;
        }

        public async Task<TodoItem> CreateAsync(TodoItem todoItem)
        {
            var todoItemCreated =  _todoItemRepository.Add(todoItem);
            await _unitOfWork.SaveAsync();

            return todoItemCreated;
        }

        public void Delete(int id)
        {
            var todoItem = _todoItemRepository.Get(id);

            if(todoItem == null)
            {
                throw new ArgumentException($"Item not found with id {id}");
            }

            _todoItemRepository.Delete(todoItem);
            _unitOfWork.Save();
        }

        public async Task DeleteAsync(int id)
        {
            var todoItem = _todoItemRepository.Get(id);

            if (todoItem == null)
            {
                throw new ArgumentException($"Item not found with id {id}");
            }

            _todoItemRepository.Delete(todoItem);
            await _unitOfWork.SaveAsync();
        }

        public TodoItem Get(int id)
        {
            var todoItem = _todoItemRepository.Get(id);

            if (todoItem == null)
            {
                throw new ArgumentException($"Item not found with id {id}");
            }

            return todoItem;
        }

        public IEnumerable<TodoItem> Get()
        {
            return _todoItemRepository.Get().ToList();
        }

        public void Update(TodoItem todoItem)
        {
            _todoItemRepository.Update(todoItem);
            _unitOfWork.Save();
        }

        public async Task UpdateAsync(TodoItem todoItem)
        {
             _todoItemRepository.Update(todoItem);
            await _unitOfWork.SaveAsync();
        }
    }
}
