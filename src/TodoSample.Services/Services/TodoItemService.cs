using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoSample.ApplicationCore.Entities;
using TodoSample.ApplicationCore.Interfaces;
using TodoSample.ApplicationCore.Models;
using TodoSample.ApplicationCore.Services.Interfaces;

namespace TodoSample.Services.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly IRepository<TodoItem> _todoItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoItemService(IRepository<TodoItem> todoItemRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TodoItem Create(TodoItemCreate todoItemCreate)
        {
            var todoItem = _mapper.Map<TodoItem>(todoItemCreate);

            var todoItemCreated = _todoItemRepository.Add(todoItem);
            _unitOfWork.Save();

            return todoItemCreated;
        }

        public async Task<TodoItem> CreateAsync(TodoItemCreate todoItemCreate)
        {
            var todoItem = _mapper.Map<TodoItem>(todoItemCreate);

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

        public void Update(TodoItemUpdate todoItemUpdate)
        {
            var todoItem = _mapper.Map<TodoItem>(todoItemUpdate);
            _todoItemRepository.Update(todoItem);
            _unitOfWork.Save();
        }

        public async Task UpdateAsync(TodoItemUpdate todoItemUpdate)
        {
            var todoItem = _mapper.Map<TodoItem>(todoItemUpdate);
            _todoItemRepository.Update(todoItem);
            await _unitOfWork.SaveAsync();
        }
    }
}
