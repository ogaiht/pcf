
using PFC.Infrastructure.DataModels.Common;

namespace PFC.Infrastructure.Data.Repositories;

public interface IListable<TFilter, TResult>
{
    Task<PagedResult<TResult>> ListAsync(PagedFilter<TFilter> filter, CancellationToken cancellationToken = default);
}