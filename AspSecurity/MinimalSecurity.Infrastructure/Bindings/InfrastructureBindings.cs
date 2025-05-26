using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalSecurity.Application.Interfaces;
using MinimalSecurity.Infrastructure.Authentication;
using MinimalSecurity.Infrastructure.Authentication.Handler;
using MinimalSecurity.Infrastructure.DataAccess;
using MinimalSecurity.Infrastructure.DataAccess.Users;
using MinimalSecurity.Infrastructure.Hasher;
using MinimalSecurity.Infrastructure.Jwt;

namespace MinimalSecurity.Infrastructure.Bindings;
public static class InfrastructureBindings
{
    public static IServiceCollection AddInfrastructureBindings( this IServiceCollection services, IConfiguration configuration )
    {
        services.AddDbContext<ApplicationDbContext>( options =>
        {
            options.UseSqlServer( configuration.GetConnectionString( "MsSql" ) );
        } );

        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHash, PasswordHash>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPermissionService, PermissionService>();

        services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

        return services;
    }
}
