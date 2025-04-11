using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PFC.Infrastructure.Data.Repositories;
using PFC.Infrastructure.DataModels.Common;
using PFC.Infrastructure.DataModels.Entities;
using PFC.Infrastructure.Helpers;

namespace PFC.Data.EntityFramework.Repositories;

public abstract class Repository<TEntity, TId, TDbContext>(
    TDbContext dbContext,
    ILogger logger,
    IExceptionHelper exceptionHelper)
        : IRepository<TEntity, TId>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TId>, new()
{
    protected TDbContext DbContext => dbContext;
    protected IExceptionHelper ExceptionHelper => exceptionHelper;
    protected ILogger Logger => logger;
    public virtual async Task<TId> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        ExceptionHelper.CheckArgumentNullException(entity, nameof(entity));
        await ExecuteAndSaveAsync( async () => await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken: cancellationToken), cancellationToken);
        return entity.Id;
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        ExceptionHelper.CheckArgumentNullException(entities, nameof(entities));
        var enumerable = entities as TEntity[] ?? entities.ToArray();
        if (!enumerable.Any())
        {
            return;
        }
        await ExecuteAndSaveAsync(async () => await DbContext.Set<TEntity>().AddRangeAsync(enumerable, cancellationToken), cancellationToken);
    }

    public virtual async Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken = default)
    {
        ExceptionHelper.CheckArgumentNullException(id, nameof(id));
        return await ExecuteAndSaveAsync(() =>
        {
            DbContext.Set<TEntity>().Remove(new TEntity { Id = id });
            return Task.CompletedTask;
        }, cancellationToken) > 0;
    }

    public virtual async Task<TEntity?> GetAsync(TId id, CancellationToken cancellationToken = default)
    {
        ExceptionHelper.CheckArgumentNullException(id, nameof(id));
        var entity = await DbContext.Set<TEntity>().FindAsync([id], cancellationToken);
        return entity;
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        ExceptionHelper.CheckArgumentNullException(entity, nameof(entity));
        DbContext.Set<TEntity>().Update(entity);
        return await DbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public virtual async Task<PagedResult<TEntity>> GetAllAsync(ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default)
    {
        ExceptionHelper.CheckArgumentNullException(specification, nameof(specification));
        var query = DbContext.Set<TEntity>().AsQueryable();
        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }

        if (specification.Includes != null)
        {
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
        }

        if (specification.OrderBy != null)
        {
            query = query.OrderBy(specification.OrderBy);
        }

        if (specification.OrderByDescending != null)
        {
            query = query.OrderByDescending(specification.OrderByDescending);
        }
        var totalCount = await query.CountAsync(cancellationToken);
        if (specification.IsPagingEnabled)
        {
            query = query.Skip(specification.Skip).Take(specification.Take);
        }
        var entities = await query.ToListAsync(cancellationToken);
        return new PagedResult<TEntity>(entities,
            specification.IsPagingEnabled ? specification.Skip : 0,
            specification.IsPagingEnabled ? specification.Take : totalCount,
            totalCount);
    }
    protected int ExecuteAndSave(Action execution)
    {
        execution();
        return DbContext.SaveChanges();
    }

    protected async Task<int> ExecuteAndSaveAsync(Func<Task> execution, CancellationToken cancellationToken = default)
    {
        await execution();
        return await DbContext.SaveChangesAsync(cancellationToken);
    }
}