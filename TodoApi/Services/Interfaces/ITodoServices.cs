namespace TodoApi.Services.Interfaces;

using TodoApi.Models;


public interface ITodoService
{
        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem?> GetByIdAsync(int id);
        Task<TodoItem> CreateAsync(TodoItem item);
        Task<bool> UpdateAsync(int id, TodoItem updatedItem);
        Task<bool> DeleteAsync(int id);
}