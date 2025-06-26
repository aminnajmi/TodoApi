using AutoMapper;
using TodoApi.Dtos;
using TodoApi.Models;
using TodoApi.Models.DTOs;

namespace TodoApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem, TodoItemDto>();
            CreateMap<CreateTodoDto, TodoItem>();
            CreateMap<UpdateTodoDto, TodoItem>();
        }
    }
}