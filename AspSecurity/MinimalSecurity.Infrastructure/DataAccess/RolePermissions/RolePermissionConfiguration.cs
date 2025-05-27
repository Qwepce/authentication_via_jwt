using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalSecurity.Domain.Enums;
using MinimalSecurity.Infrastructure.Authentication.Helpers;

namespace MinimalSecurity.Infrastructure.DataAccess.RolePermissions;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermissionEntity>
{
    private readonly AuthorizationOptions _authOptions;

    public RolePermissionConfiguration( AuthorizationOptions authOptions )
    {
        _authOptions = authOptions;
    }

    public void Configure( EntityTypeBuilder<RolePermissionEntity> builder )
    {
        builder.HasKey( rp => new { rp.RoleId, rp.PermissionId } );

        builder.HasData( ParsedRolePermissions() );
    }

    private RolePermissionEntity[] ParsedRolePermissions()
    {
        return _authOptions.RolePermissions
            .SelectMany( rp => rp.Permissions
                .Select( p => new RolePermissionEntity
                {
                    RoleId = ( int )Enum.Parse<RoleEnum>( rp.Role ),
                    PermissionId = ( int )Enum.Parse<Permission>( p )
                } ) )
            .ToArray();
    }
}