namespace PFC.Infrastructure.DataModels.Common;

public static class DtosCommonExtensions
{
    public static PagedResult<TOutput> As<TInput, TOutput>(this PagedResult<TInput> pagedResult,
        Func<TInput, TOutput> mapper)
    {
        var output = pagedResult.Results.Select(mapper);
        return new PagedResult<TOutput>(output, pagedResult.Offset, pagedResult.Limit, pagedResult.Total);
    }
}