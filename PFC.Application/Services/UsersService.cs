using AutoMapper;
using PFC.Application.Data.Repositories;
using PFC.Domain.Entities;
using PFC.Dtos.Users;

namespace PFC.Application.Services;

public class UsersService(IUsersRepository repository, IMapper mapper)
    : CrudService<User, Guid, IUsersRepository, CreateUserDto, UpdateUserDto, UserDto, UsersFilter>(repository, mapper), IUsersService
{
    
}