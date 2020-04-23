using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TodoSample.ApplicationCore.Services.Interfaces;
using TodoSample.Infrastructure.Extensions;
using TodoSample.Services.Mapper;
using TodoSample.Services.Services;

namespace TodoSample.Services.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddTodoSampleModule(this IServiceCollection service)
        {
            service.AddEntityFramework();

            service.AddAutoMapper(typeof(TodoItemProfile));

            service.AddTransient<ITodoItemService, TodoItemService>();
        }
    }
}
