// Dtos/UpdateTodoDto.cs
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos;

public class UpdateTodoDto
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(100, ErrorMessage = "Title must be at most 100 characters.")]
    public required string Title { get; set; }
    public bool IsCompleted { get; set; }
}
