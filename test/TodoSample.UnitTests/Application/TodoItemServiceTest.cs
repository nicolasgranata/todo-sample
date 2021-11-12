using AutoMapper;
using Moq;
using TodoSample.Application.Interfaces;
using TodoSample.Application.Services;
using TodoSample.Domain.Entities;
using TodoSample.Services.Mapper;
using Xunit;

namespace TodoSample.UnitTests.Services
{
    [Collection("DbContext collection")]
    public class TodoItemServiceTest 
    {
        private readonly DbContextFixture _dbContextFixture;

        public TodoItemServiceTest(DbContextFixture dbContextFixture)
        {
            _dbContextFixture = dbContextFixture;
        }

        [Fact]
        public void Get_ById_ReturnsTodoItem()
        {
            // Arrange      
            var repository = new Mock<IRepository<TodoItem>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TodoItemProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            repository.Setup(r => r.Get(1)).Returns(GetTodoItemById(1));    


            var todoItemService = new TodoItemService(repository.Object, unitOfWork.Object, mapper);

            // Act
            var result = todoItemService.Get(1);

            // Assert
            Assert.Equal(1, result.Id);
            Assert.Equal("First item", result.Name);
            Assert.False(result.IsCompleted);
        }

        [Fact]
        public void Get_ById_ReturnsNull()
        {
            // Arrange      
            var repository = new Mock<IRepository<TodoItem>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TodoItemProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            repository.Setup(r => r.Get(2)).Returns(GetTodoItemById(2));

            var todoItemService = new TodoItemService(repository.Object, unitOfWork.Object, mapper);

            // Act
            var result = todoItemService.Get(2);

            // Assert
            Assert.Null(result);
        }


        private TodoItem GetTodoItemById(long id)
        {
           return _dbContextFixture.TodoSampleDbContext.TodoItems.Find(id);
        }
    }
}
