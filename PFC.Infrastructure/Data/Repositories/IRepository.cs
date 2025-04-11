using PFC.Infrastructure.DataModels.Entities;

namespace PFC.Infrastructure.Data.Repositories;

public interface IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
{
    Task<TId> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity?> GetAsync(TId id, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken = default);
    
}