namespace TodoApi.Models.DTOs
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}