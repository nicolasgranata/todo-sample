using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoSample.Domain.Entities;
using TodoSample.Infrastructure.Persistence.EntityFramework;
using TodoSample.Infrastructure.Persistence.Repositories;
using TodoSample.Application.Interfaces;

namespace TodoSample.Infrastructure.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection service)
        {
            service.AddDbContext<TodoSampleDbContext>(options => {
                options.UseInMemoryDatabase("TodoSampleInMemoryDB");
            });

            service.AddScoped<IUnitOfWork, EntityFrameworkUnitOfWork<TodoSampleDbContext>>();
            service.AddScoped<IRepository<TodoItem>, TodoItemRepository>();

            return service;
        }
    }
}
