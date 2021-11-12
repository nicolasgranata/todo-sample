using AutoMapper;
using TodoSample.Domain.Entities;
using TodoSample.Domain.Models;

namespace TodoSample.Services.Mapper
{
    public class TodoItemProfile : Profile
    {
        public TodoItemProfile()
        {
            CreateMap<TodoItemCreate, TodoItem>();
            CreateMap<TodoItemUpdate, TodoItem>();
        }
    }
}
