using PFC.Infrastructure.DataModels.Entities;

namespace PFC.Data.InMemory.Core;

public class DataSource<TId>(IIdentityProvider<TId> identityProvider) : IDataSource<TId> where TId : notnull
{
    private readonly Dictionary<Type, object>
        _data = new ();
    private readonly IIdentityProvider<TId> _identityGenerator = identityProvider;
    
    public IDataCollection<TId, TEntity> Get<TEntity>() where TEntity : class, IEntity<TId>
    {
        if (_data.GetValueOrDefault(typeof(TEntity)) is not IDictionary<TId, TEntity> collection)
        {
            collection = new Dictionary<TId, TEntity>();
            _data.Add(typeof(TEntity), collection);
        }
        return new DataCollection<TId, TEntity>(collection, _identityGenerator);
    }
}