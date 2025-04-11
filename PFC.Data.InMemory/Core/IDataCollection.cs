using PFC.Domain.Entities;
using PFC.Infrastructure.DataModels.Entities;

namespace PFC.Data.InMemory.Core;

public interface IDataCollection<TId, TEntity> : IEnumerable<TEntity> where TEntity : class, IEntity<TId> 
{
    Task<TId> AddAsync(TEntity entity);
    Task<TEntity?> GetAsync(TId id);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TId id);
}