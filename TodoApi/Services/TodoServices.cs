namespace TodoApi.Services;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using TodoApi.Services.Interfaces;
using TodoApi.Data;

public class TodoServices : ITodoService
    {
        private readonly AppDbContext _context;

        public TodoServices(AppDbContext context)
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
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return false;

            item.Title = updatedItem.Title;
            item.IsCompleted = updatedItem.IsCompleted;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return false;

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
}