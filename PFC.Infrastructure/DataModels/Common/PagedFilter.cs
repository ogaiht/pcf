namespace PFC.Infrastructure.DataModels.Common;

public record PagedFilter<TFilter>(TFilter Filter, int? Offset, int? Limit);