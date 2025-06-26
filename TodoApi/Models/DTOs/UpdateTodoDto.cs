// Dtos/UpdateTodoDto.cs
namespace TodoApi.Dtos;

public class UpdateTodoDto
{
    public required string Title { get; set; }
    public bool IsCompleted { get; set; }
}
