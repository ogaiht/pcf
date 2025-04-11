using PFC.Infrastructure.DataModels.Entities;

namespace PFC.Data.InMemory.Core;

public interface IDataSource<TId>
{
    IDataCollection<TId, TEntity> Get<TEntity>() where TEntity : class, IEntity<TId>;
}