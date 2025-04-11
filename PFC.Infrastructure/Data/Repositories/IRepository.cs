using PFC.Infrastructure.DataModels.Entities;

namespace PFC.Infrastructure.Data.Repositories;

public interface IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
{
    Task<TId> CreateAsync(TEntity entity);
    Task<TEntity?> GetAsync(TId id);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TId id);
}