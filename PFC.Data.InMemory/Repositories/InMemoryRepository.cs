using PFC.Application.Data.Repositories;
using PFC.Data.InMemory.Core;
using PFC.Domain.Entities;
using PFC.Infrastructure.Data.Repositories;
using PFC.Infrastructure.DataModels.Entities;

namespace PFC.Data.InMemory.Repositories;

public abstract class InMemoryRepository<TEntity, TId>(IDataSource<TId> dataSource) : IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
{
    protected IDataSource<TId> DataSource => dataSource;
    
    protected IDataCollection<TId, TEntity> Collection => DataSource.Get<TEntity>();
    public virtual Task<TId> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return DataSource.Get<TEntity>().AddAsync(entity);
    }

    public virtual Task<TEntity?> GetAsync(TId id, CancellationToken cancellationToken = default)
    {
        return DataSource.Get<TEntity>().GetAsync(id);
    }

    public virtual Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return DataSource.Get<TEntity>().UpdateAsync(entity);
    }

    public virtual Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken = default)
    {
        return DataSource.Get<TEntity>().DeleteAsync(id);
    }
}