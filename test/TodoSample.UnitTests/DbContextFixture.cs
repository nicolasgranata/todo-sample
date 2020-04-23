using Microsoft.EntityFrameworkCore;
using System;
using TodoSample.ApplicationCore.Entities;
using TodoSample.Infrastructure.Data.EntityFramework;
using Xunit;

namespace TodoSample.UnitTests
{
    public class DbContextFixture : IDisposable
    {
        public DbContextFixture()
        {
            CreateDbContext();
        }
        public void Dispose()
        {
            TodoSampleDbContext.Dispose();
        }

        public TodoSampleDbContext TodoSampleDbContext { get; private set; }

        private void CreateDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TodoSampleDbContext>();
            dbContextOptions.UseInMemoryDatabase("UnitTestDatabase");

            TodoSampleDbContext = new TodoSampleDbContext(dbContextOptions.Options);
            TodoSampleDbContext.Add(new TodoItem
            {
                Id = 1,
                Name = "First item",
                CreatedAt = DateTime.UtcNow,
                IsCompleted = false
            });
            TodoSampleDbContext.SaveChanges();
        }
    }

    [CollectionDefinition("DbContext collection")]
    public class DbContextFixtureCollection : ICollectionFixture<DbContextFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
