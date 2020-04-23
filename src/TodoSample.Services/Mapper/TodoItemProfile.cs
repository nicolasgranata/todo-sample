using AutoMapper;
using TodoSample.ApplicationCore.Entities;
using TodoSample.ApplicationCore.Models;

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
