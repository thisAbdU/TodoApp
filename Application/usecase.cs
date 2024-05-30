using TodoApp.Application.Commands;
using TodoApp.Application.Interfaces;
using TodoApp.Core.Entities;
using System.Threading.Tasks;

namespace TodoApp.Application.UseCases
{
    public class CreateTodoTaskHandler
    {
        private readonly ITodoTaskRepository _repository;

        public CreateTodoTaskHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTodoTaskCommand command)
        {
            var task = new TodoTask
            {
                Title = command.Title,
                Description = command.Description,
                CreatedAt = DateTime.UtcNow,
                DueDate = command.DueDate,
                IsCompleted = false,
                UserId = 1 //TODO:This should be dynamically set based on logged-in user
            };

            await _repository.AddAsync(task);
        }
    }
}
