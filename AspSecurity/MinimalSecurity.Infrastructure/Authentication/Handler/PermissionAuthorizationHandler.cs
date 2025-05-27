using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MinimalSecurity.Application.Interfaces;
using MinimalSecurity.Domain.Enums;

namespace MinimalSecurity.Infrastructure.Authentication.Handler;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IServiceScopeFactory _serviceScope;

    public PermissionAuthorizationHandler( IServiceScopeFactory serviceScope )
    {
        _serviceScope = serviceScope;
    }

    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement )
    {
        Claim userId = context.User.Claims.FirstOrDefault(
            c => c.Type == "userId"
        );

        if ( userId is null || !Guid.TryParse( userId.Value, out Guid id ) )
        {
            return;
        }

        using var scope = _serviceScope.CreateScope();

        IPermissionService permissionService = scope.ServiceProvider.GetRequiredService<IPermissionService>();
        HashSet<Permission> permissions = await permissionService.GetPermissionsAsync( id );

        if ( permissions.Intersect( requirement.Permissions ).Any() )
        {
            context.Succeed( requirement );
        }
    }
}