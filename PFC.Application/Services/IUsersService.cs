using PFC.Dtos.Users;

namespace PFC.Application.Services;

public interface IUsersService : ICrudServices<Guid, CreateUserDto, UpdateUserDto, UserDto, UsersFilter>
{
    
}