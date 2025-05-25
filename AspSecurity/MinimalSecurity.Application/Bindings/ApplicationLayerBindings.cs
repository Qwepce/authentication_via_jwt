using Microsoft.Extensions.DependencyInjection;
using MinimalSecurity.Application.Interfaces;
using MinimalSecurity.Application.Services;

namespace MinimalSecurity.Application.Bindings;
public static class ApplicationLayerBindings
{
    public static IServiceCollection AddApplicationLayerBindings( this IServiceCollection services )
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
