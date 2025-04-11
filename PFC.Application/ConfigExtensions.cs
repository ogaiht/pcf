using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PFC.Application.Services;
using Mapper = PFC.Application.Mappers.Mapper;

namespace PFC.Application;

public static class ConfigExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddAutoMapper(typeof(Mapper))
            .AddScoped<IUsersService, UsersService>();
    }
}