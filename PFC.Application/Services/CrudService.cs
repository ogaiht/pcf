using AutoMapper;
using PFC.Infrastructure.Data.Repositories;
using PFC.Infrastructure.DataModels.Common;
using PFC.Infrastructure.DataModels.Entities;

namespace PFC.Application.Services;

public abstract class CrudService<TEntity, TId, TRepository, TCreateDto, TUpdateDto, TDto, TFilter>(
    TRepository repository,
    IMapper mapper) : ICrudServices<TId, TCreateDto, TUpdateDto, TDto, TFilter>
    where TRepository : IRepository<TEntity, TId>, IListable<TFilter, TEntity>
    where TEntity : class, IEntity<TId>
{
    protected TRepository Repository => repository;
    protected IMapper Mapper => mapper;

    public virtual async Task<TId> CreateAsync(TCreateDto createDto)
    {
        var entity = Mapper.Map<TCreateDto, TEntity>(createDto);
        await Repository.CreateAsync(entity);
        return entity.Id;
    }

    public virtual async Task<bool> UpdateAsync(TId id, TUpdateDto updateDto)
    {
        var entity = await Repository.GetAsync(id);
        if (entity == null)
        {
            return false;
        }
        entity = Mapper.Map(updateDto, entity);
        await Repository.UpdateAsync(entity);
        return true;
    }

    public virtual async Task<TDto?> GetAsync(TId id)
    {
        var entity = await Repository.GetAsync(id);
        TDto? dto = default;
        if (entity != null)
        {
            dto = Mapper.Map<TDto>(entity);
        }
        return dto;
    }

    public virtual Task<bool> DeleteAsync(TId id)
    {
        return Repository.DeleteAsync(id);
    }

    public virtual async Task<PagedResult<TDto>> ListAsync(PagedFilter<TFilter> filter)
    {
        var result = await Repository.ListAsync(filter);
        return result.As<TEntity, TDto>(entity => Mapper.Map<TDto>(entity));
    }
}