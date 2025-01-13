using AutoMapper;
using BasicCRUD.Domain.DTOs.User;
using BasicCRUD.Domain.Models;

namespace BasicCRUD.Domain.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<CreateUserDto, User>();

            CreateMap<UpdateUserDto, User>();
        }
    }
}
