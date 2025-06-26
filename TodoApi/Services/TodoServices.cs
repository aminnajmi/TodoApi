// Services/TodoService.cs

using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Services.Interfaces;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _context;

        public TodoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem?> GetByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<TodoItem> CreateAsync(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> UpdateAsync(int id, TodoItem updatedItem)
        {
            var existing = await _context.TodoItems.FindAsync(id);
            if (existing == null)
                return false;

            existing.Title = updatedItem.Title;
            existing.IsCompleted = updatedItem.IsCompleted;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.TodoItems.FindAsync(id);
            if (existing == null)
                return false;

            _context.TodoItems.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
