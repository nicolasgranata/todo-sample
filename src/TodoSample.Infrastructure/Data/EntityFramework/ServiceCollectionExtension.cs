using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoSample.ApplicationCore.Entities;
using TodoSample.ApplicationCore.Interfaces;
using TodoSample.Infrastructure.Data.Repositories;

namespace TodoSample.Infrastructure.Data.EntityFramework
{
    public static class ServiceCollectionExtension
    {
        public static void AddEntityFramework(this IServiceCollection service)
        {
            service.AddDbContext<TodoSampleDbContext>(options => {
                options.UseInMemoryDatabase("TodoSampleInMemoryDB");
            });

            service.AddScoped<IUnitOfWork, EntityFrameworkUnitOfWork<TodoSampleDbContext>>();
            service.AddScoped<IRepository<TodoItem>, TodoItemRepository>();
        }
    }
}
