using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalSecurity.Domain.Entities;
using MinimalSecurity.Domain.Enums;

namespace MinimalSecurity.Infrastructure.DataAccess.Permissions;

public class PermissionEntityConfiguration : IEntityTypeConfiguration<PermissionEntity>
{
    public void Configure( EntityTypeBuilder<PermissionEntity> builder )
    {
        builder.ToTable( nameof( PermissionEntity ) )
            .HasKey( rp => rp.Id );

        builder.Property( rp => rp.Id )
            .HasColumnName( "id" );

        List<PermissionEntity> permissions = Enum.GetValues<Permission>()
            .Select( p => new PermissionEntity
            {
                Id = ( int )p,
                Name = p.ToString()
            } )
            .ToList();

        builder.HasData( permissions );
    }
}