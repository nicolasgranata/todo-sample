using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TodoSample.Services.Mapper;
using TodoSample.Application.Services;
using TodoSample.Application.Interfaces;

namespace TodoSample.Services.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(TodoItemProfile));

            service.AddTransient<ITodoItemService, TodoItemService>();

            return service;
        }
    }
}
