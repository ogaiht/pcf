using System.Collections;
using PFC.Infrastructure.DataModels.Entities;

namespace PFC.Data.InMemory.Core;

public class DataCollection<TId, TEntity>(IDictionary<TId, TEntity> source, IIdentityProvider<TId> identityProvider)
    : IDataCollection<TId, TEntity>
    where TEntity : class, IEntity<TId>
{
    private readonly IDictionary<TId, TEntity> _source = source;
    private readonly IIdentityProvider<TId> _identityProvider = identityProvider;

    public Task<TId> AddAsync(TEntity entity)
    {
        var id = _identityProvider.Next(typeof(TEntity));
        entity.Id = id;
        _source.Add(id, entity);
        return  Task.FromResult(id);
    }

    public Task<TEntity?> GetAsync(TId id)
    {
        TEntity? entity = null;
        if (_source.ContainsKey(id))
        {
            entity = _source[id];          
        }
        return Task.FromResult(entity);
    }

    public Task<bool> UpdateAsync(TEntity entity)
    {
        if (_source.ContainsKey(entity.Id))
        {
            _source[entity.Id] = entity;
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<bool> DeleteAsync(TId id)
    {
        if (_source.ContainsKey(id))
        {
            _source.Remove(id);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public IEnumerator<TEntity> GetEnumerator()
    {
        return _source.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}