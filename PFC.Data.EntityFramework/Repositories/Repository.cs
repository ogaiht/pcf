using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PFC.Infrastructure.Data.Repositories;
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

        

        public virtual async Task<TId> CreateAsync(TEntity entity)
        {
            ExceptionHelper.CheckArgumentNullException(entity, nameof(entity));
            await ExecuteAndSaveAsync( async () => await DbContext.Set<TEntity>().AddAsync(entity));
            return entity.Id;
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            ExceptionHelper.CheckArgumentNullException(entities, nameof(entities));
            var enumerable = entities as TEntity[] ?? entities.ToArray();
            if (!enumerable.Any())
            {
                return;
            }
            await ExecuteAndSaveAsync(async () => await DbContext.Set<TEntity>().AddRangeAsync(enumerable));
        }

        public virtual async Task<bool> DeleteAsync(TId id)
        {
            ExceptionHelper.CheckArgumentNullException(id, nameof(id));
            return await ExecuteAndSaveAsync(() =>
            {
                DbContext.Set<TEntity>().Remove(new TEntity { Id = id });
                return Task.CompletedTask;
            }) > 0;
        }

        public virtual async Task<TEntity?> GetAsync(TId id)
        {
            ExceptionHelper.CheckArgumentNullException(id, nameof(id));
            var entity = await DbContext.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            ExceptionHelper.CheckArgumentNullException(entity, nameof(entity));
            DbContext.Set<TEntity>().Update(entity);
            return await DbContext.SaveChangesAsync() > 0;
        }

        protected int ExecuteAndSave(Action execution)
        {
            execution();
            return DbContext.SaveChanges();
        }

        protected async Task<int> ExecuteAndSaveAsync(Func<Task> execution)
        {
            await execution();
            return await DbContext.SaveChangesAsync();
        }
    }