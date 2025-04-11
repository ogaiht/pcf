using PFC.Infrastructure.DataModels.Common;

namespace PFC.Application.Services;

public interface ICrudServices<TId, in TCreateDto, in TUpdateDto, TDto, TFilter>
{
    Task<TId> CreateAsync(TCreateDto dto);
    Task<bool> UpdateAsync(TId id, TUpdateDto dto);
    Task<bool> DeleteAsync(TId id);
    Task<TDto?> GetAsync(TId id);

    Task<PagedResult<TDto>> ListAsync(PagedFilter<TFilter> filter);
}