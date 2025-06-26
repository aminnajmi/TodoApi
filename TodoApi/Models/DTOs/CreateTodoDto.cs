// Dtos/CreateTodoDto.cs
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos;

public class CreateTodoDto
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(100, ErrorMessage = "Title must be at most 100 characters.")]
    public string Title { get; set; } = string.Empty;
    
    public bool IsCompleted { get; set; }
}
