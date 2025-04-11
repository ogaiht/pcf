using PFC.Domain.Entities;
using PFC.Dtos.Users;
using PFC.Infrastructure.Data.Repositories;

namespace PFC.Application.Data.Repositories;

public interface IUsersRepository : IRepository<User, Guid>, IListable<UsersFilter, User>
{
    
}