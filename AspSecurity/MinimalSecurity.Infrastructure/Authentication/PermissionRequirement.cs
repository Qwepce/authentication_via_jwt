using Microsoft.AspNetCore.Authorization;
using MinimalSecurity.Domain.Enums;

namespace MinimalSecurity.Infrastructure.Authentication;

public class PermissionRequirement : IAuthorizationRequirement
{
    public Permission[] Permissions { get; set; } = [];

    public PermissionRequirement( Permission[] permissions )
    {
        Permissions = permissions;
    }
}