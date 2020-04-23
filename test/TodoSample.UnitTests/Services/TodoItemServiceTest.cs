using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using TodoSample.ApplicationCore.Entities;
using TodoSample.ApplicationCore.Interfaces;
using TodoSample.Infrastructure.Data.EntityFramework;
using TodoSample.Infrastructure.Data.Repositories;
using TodoSample.Services.Mapper;
using TodoSample.Services.Services;
using Xunit;

namespace TodoSample.UnitTests.Services
{
    public class TodoItemServiceTest 
    { 
        [Fact]
        public void Get_ById_ReturnsTodoItem()
        {
            // Arrange      
            var dbContextOptions = new DbContextOptionsBuilder<TodoSampleDbContext>();
            dbContextOptions.UseInMemoryDatabase("UnitTestDatabase");

            var dbContext = new TodoSampleDbContext(dbContextOptions.Options);
            dbContext.Add(new TodoItem
            {
                Id = 1,
                Name = "First item",
                CreatedAt = DateTime.UtcNow,
                IsCompleted = false
            });
            dbContext.SaveChanges();

            var repository = new TodoItemRepository(dbContext);
            var unitOfWork = new Mock<IUnitOfWork>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TodoItemProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();


            var todoItemService = new TodoItemService(repository, unitOfWork.Object, mapper);

            // Act
            var result = todoItemService.Get(1);

            // Assert
            Assert.Equal(1, result.Id);
            Assert.Equal("First item", result.Name);
            Assert.False(result.IsCompleted);
        }

        [Fact]
        public void Get_ById_ReturnsArgumentException()
        {
            // Arrange      
            var dbContextOptions = new DbContextOptionsBuilder<TodoSampleDbContext>();
            dbContextOptions.UseInMemoryDatabase("UnitTestDatabase");

            var dbContext = new TodoSampleDbContext(dbContextOptions.Options);
            dbContext.Add(new TodoItem
            {
                Id = 1,
                Name = "First item",
                CreatedAt = DateTime.UtcNow,
                IsCompleted = false
            });
            dbContext.SaveChanges();

            var repository = new TodoItemRepository(dbContext);
            var unitOfWork = new Mock<IUnitOfWork>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TodoItemProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            var todoItemService = new TodoItemService(repository, unitOfWork.Object, mapper);

            // Act Assert
            Assert.Throws<ArgumentException>(() => todoItemService.Get(2));
        }
    }
}
