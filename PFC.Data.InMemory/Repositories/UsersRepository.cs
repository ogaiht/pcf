using PFC.Application.Data.Repositories;
using PFC.Data.InMemory.Core;
using PFC.Domain.Entities;
using PFC.Dtos.Users;
using PFC.Infrastructure.DataModels.Common;

namespace PFC.Data.InMemory.Repositories;

public class UsersRepository(IDataSource<Guid> dataSource) : InMemoryRepository<User, Guid>(dataSource), IUsersRepository
{
    public Task<PagedResult<User>> ListAsync(PagedFilter<UsersFilter> filter, CancellationToken cancellationToken = default)
    {
        IEnumerable<User> users = Collection;
        if (!string.IsNullOrEmpty(filter.Filter.Search))
        {
            users = users.Where(u => u.Name.Contains(filter.Filter.Search));
        }
        var total  = users.Count();

        if (filter.Offset != null)
        {
            users = users.Skip(filter.Offset.Value);
        }

        if (filter.Limit != null)
        {
            users = users.Take(filter.Limit.Value);
        }
        return Task.FromResult(new PagedResult<User>(users, total, filter.Offset.Value, filter.Limit.Value));
    }
}