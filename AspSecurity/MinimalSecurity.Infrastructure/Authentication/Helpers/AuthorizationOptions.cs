namespace MinimalSecurity.Infrastructure.Authentication.Helpers;

public class AuthorizationOptions
{
    public AuthorizationRolePermissions[] RolePermissions { get; set; } = [];
}

public class AuthorizationRolePermissions
{
    public string Role { get; set; } = string.Empty;

    public string[] Permissions { get; set; } = [];
}