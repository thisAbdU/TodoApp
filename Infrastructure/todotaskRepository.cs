using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Interfaces;
using TodoApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.Infrastructure.Data
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly TodoAppDbContext _context;

        public TodoTaskRepository(TodoAppDbContext context)
        {
            _context = context;
        }

        public async Task<TodoTask?> GetByIdAsync(int id)
        {
            return await _context.tasks.FindAsync(id);
        }

        public async Task<IEnumerable<TodoTask>> GetAllAsync()
        {
            return await _context.tasks.ToListAsync();
        }

        public async Task AddAsync(TodoTask task)
        {
            _context.tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TodoTask task)
        {
            _context.tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _context.tasks.FindAsync(id);
            if (task != null)
            {
                _context.tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }

}