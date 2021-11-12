using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoSample.Application.Interfaces;
using TodoSample.Domain.Entities;
using TodoSample.Domain.Models;

namespace TodoSample.WebApi.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;
        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
            
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TodoItem>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            return Ok(_todoItemService.Get());
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TodoItem))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TodoItem>> Post(TodoItemCreate todoItemCreate)
        {
            var todoItemCreated = await _todoItemService.CreateAsync(todoItemCreate);

            return Created("Get", todoItemCreated);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Put(int id, TodoItemUpdate todoItemUpdate)
        {
            todoItemUpdate.Id = id;
            await _todoItemService.UpdateAsync(todoItemUpdate);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            await _todoItemService.DeleteAsync(id);

            return NoContent();
        }
    }
}
