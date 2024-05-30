using TodoApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.Application.Interfaces
{
    public interface ITodoTaskRepository
    {
        Task<TodoTask?> GetByIdAsync(int id);
        Task<IEnumerable<TodoTask>> GetAllAsync();
        Task AddAsync(TodoTask task);
        Task UpdateAsync(TodoTask task);
        Task DeleteAsync(int id);
    }
}
