// Dtos/CreateTodoDto.cs
namespace TodoApi.Dtos;

public class CreateTodoDto
{
    public string Title { get; set; } = string.Empty;
    
    public bool IsCompleted { get; set; }
}
