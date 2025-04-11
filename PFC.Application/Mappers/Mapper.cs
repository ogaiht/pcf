using AutoMapper;
using PFC.Domain.Entities;
using PFC.Dtos.Users;

namespace PFC.Application.Mappers;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<User, UserDto>()
            .ForCtorParam("Name", opt => opt.MapFrom(e => e.Name))
            .ForCtorParam("Email", opt => opt.MapFrom(e => e.Email));
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
    }
}