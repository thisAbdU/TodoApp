using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Commands;
using TodoApp.Application.DTOs;
using TodoApp.Application.Interfaces;
using TodoApp.Application.UseCases;
using System.Threading.Tasks;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoTasksController : ControllerBase
    {
        private readonly ITodoTaskRepository _repository;
        private readonly CreateTodoTaskHandler _createHandler;

        public TodoTasksController(ITodoTaskRepository repository, CreateTodoTaskHandler createHandler)
        {
            _repository = repository;
            _createHandler = createHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _repository.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoTaskCommand command)
        {
            await _createHandler.Handle(command);
            return CreatedAtAction(nameof(GetById), new { id = command.Title }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TodoTaskDto dto)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.DueDate = dto.DueDate;
            task.IsCompleted = dto.IsCompleted;

            await _repository.UpdateAsync(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
