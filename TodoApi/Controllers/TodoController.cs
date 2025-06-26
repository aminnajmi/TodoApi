// Controllers/TodoController.cs

using Microsoft.AspNetCore.Mvc;
using TodoApi.Services.Interfaces;
using TodoApi.Dtos;
using TodoApi.Models;
using AutoMapper;
using TodoApi.Models.DTOs;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    private readonly IMapper _mapper;

    public TodoController(ITodoService todoService, IMapper mapper)
    {
        _todoService = todoService;
        _mapper = mapper;
    }

    // GET: api/todo
    [HttpGet]
    public async Task<ActionResult<List<TodoItemDto>>> GetAll()
    {
        var todos = await _todoService.GetAllAsync();
        var result = _mapper.Map<List<TodoItemDto>>(todos);
        return Ok(result);
    }

    // GET: api/todo/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItemDto>> GetById(int id)
    {
        var todo = await _todoService.GetByIdAsync(id);
        if (todo == null)
            return NotFound();

        return Ok(_mapper.Map<TodoItemDto>(todo));
    }

    // POST: api/todo
    [HttpPost]
    public async Task<ActionResult<TodoItemDto>> Create(CreateTodoDto dto)
    {
        var todo = _mapper.Map<TodoItem>(dto);
        var created = await _todoService.CreateAsync(todo);
        var resultDto = _mapper.Map<TodoItemDto>(created);

        return CreatedAtAction(nameof(GetById), new { id = resultDto.Id }, resultDto);
    }

    // PUT: api/todo/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTodoDto dto)
    {
        var updated = _mapper.Map<TodoItem>(dto);
        var success = await _todoService.UpdateAsync(id, updated);
        if (!success)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/todo/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _todoService.DeleteAsync(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
}
