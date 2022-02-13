using AutoMapper;
using Todo.DomainModels;
using ToDO.Domain;

namespace Todo.Services.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TodoItem, TodoItemDTO>();
            //CreateMap<TodoItemDTO, TodoItem>();

            CreateMap<User, UserDTO>();
            //CreateMap<UserDTO, User>();
        }
    }
}
