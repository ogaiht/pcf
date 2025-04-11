using PFC.Infrastructure.DataModels.Common;

namespace PFC.Dtos.Users;

public record UsersFilter(string Search, string? Sort = null, SortDirection? SortDirection = null);

