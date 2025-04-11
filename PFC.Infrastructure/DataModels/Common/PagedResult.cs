namespace PFC.Infrastructure.DataModels.Common;


public record PagedResult<TResult>(IEnumerable<TResult> Results, int Offset, int Limit, int Total);
