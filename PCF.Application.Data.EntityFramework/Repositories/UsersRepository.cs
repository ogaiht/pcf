using Microsoft.Extensions.Logging;
using PFC.Application.Data.Repositories;
using PFC.Data.EntityFramework.Repositories;
using PFC.Domain.Entities;
using PFC.Dtos.Users;
using PFC.Infrastructure.DataModels.Common;
using PFC.Infrastructure.Helpers;

namespace PCF.Application.Data.EntityFramework.Repositories;

public class UsersRepository(PcfContext context, ILogger<UsersRepository> logger, IExceptionHelper exceptionHelper) 
    : Repository<User, Guid, PcfContext>(context, logger, exceptionHelper), IUsersRepository
{
    public Task<PagedResult<User>> ListAsync(PagedFilter<UsersFilter> filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}