using Microsoft.Extensions.DependencyInjection;
using PFC.Application.Data.Repositories;
using PFC.Data.InMemory.Core;
using PFC.Data.InMemory.Repositories;

namespace PFC.Data.InMemory;

public static class InMemoryExtensions
{
    public static IServiceCollection AddInMemoryRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IIdentityProvider<Guid>, GuidIdentityProvider>()
            .AddScoped<IDataSource<Guid>, DataSource<Guid>>()
            .AddScoped<IUsersRepository, UsersRepository>();
    }
}