using AutoMapper;
using Moq;
using System;
using TodoSample.ApplicationCore.Interfaces;
using TodoSample.Infrastructure.Data.Repositories;
using TodoSample.Services.Mapper;
using TodoSample.Services.Services;
using Xunit;

namespace TodoSample.UnitTests.Services
{
    [Collection("DbContext collection")]
    public class TodoItemServiceTest 
    {
        private readonly DbContextFixture _dbContextFixture;

        public TodoItemServiceTest(DbContextFixture dbcontextFixture)
        {
            _dbContextFixture = dbcontextFixture;
        }

        [Fact]
        public void Get_ById_ReturnsTodoItem()
        {
            // Arrange      
            var repository = new TodoItemRepository(_dbContextFixture.TodoSampleDbContext);
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
            var repository = new TodoItemRepository(_dbContextFixture.TodoSampleDbContext);
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
