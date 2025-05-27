using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalSecurity.Domain.Entities;
using MinimalSecurity.Domain.Enums;
using MinimalSecurity.Infrastructure.DataAccess.RolePermissions;

namespace MinimalSecurity.Infrastructure.DataAccess.Roles;

public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure( EntityTypeBuilder<RoleEntity> builder )
    {
        builder.ToTable( nameof( RoleEntity ) )
            .HasKey( r => r.Id );

        builder.Property( r => r.Id )
            .HasColumnName( "id" );

        builder.HasMany( r => r.Permissions )
            .WithMany( p => p.Roles )
            .UsingEntity<RolePermissionEntity>(
                j => j.HasOne<PermissionEntity>().WithMany().HasForeignKey( r => r.PermissionId ),
                j => j.HasOne<RoleEntity>().WithMany().HasForeignKey( r => r.RoleId )
            );

        List<RoleEntity> roles = Enum.GetValues<RoleEnum>()
            .Select( r => new RoleEntity
            {
                Id = ( int )r,
                Name = r.ToString()
            } )
            .ToList();

        builder.HasData( roles );
    }
}