using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalSecurity.Domain.Entities;

namespace MinimalSecurity.Infrastructure.DataAccess.Users;
public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure( EntityTypeBuilder<UserEntity> builder )
    {
        builder.ToTable( nameof( UserEntity ) )
            .HasKey( u => u.Id );

        builder.Property( u => u.Id )
            .HasColumnName( "id" );

        builder.Property( u => u.Username )
            .HasMaxLength( 30 )
            .HasColumnName( "username" )
            .IsRequired();

        builder.Property( u => u.HashedPassword )
            .HasColumnName( "hashed_password" )
            .IsRequired();

        builder.Property( u => u.Email )
            .HasMaxLength( 50 )
            .HasColumnName( "email" )
            .IsRequired();

        builder.HasMany( u => u.Roles )
            .WithMany( r => r.Users )
            .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                j => j.HasOne<RoleEntity>().WithMany().HasForeignKey( "id_role" ),
                j => j.HasOne<UserEntity>().WithMany().HasForeignKey( "id_user" )
            );
    }
}
