using Microsoft.Extensions.DependencyInjection;
using TodoSample.ApplicationCore.Services;
using TodoSample.ApplicationCore.Services.Interfaces;
using TodoSample.Infrastructure.Data.EntityFramework;

namespace TodoSample.DIContainer
{
    public static class ServiceCollectionExtension
    {
        public static void AddTodoSampleModule(this IServiceCollection service)
        {
            service.AddEntityFramework();

            service.AddTransient<ITodoItemService, TodoItemService>();
        }
    }
}
