using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoSample.ApplicationCore.Entities;
using TodoSample.ApplicationCore.Services.Interfaces;

namespace TodoSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;
        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
            
        [HttpGet]
        public ActionResult<TodoItem> Get()
        {
            return Ok(_todoItemService.Get());
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var todoItem = _todoItemService.Get(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> Post(TodoItem todoItem)
        {
            var todoItemCreated = await _todoItemService.CreateAsync(todoItem);

            return Created("Get", todoItemCreated);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, TodoItem todoItem)
        {
            await _todoItemService.UpdateAsync(todoItem);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _todoItemService.DeleteAsync(id);

            return Ok();
        }
    }
}
