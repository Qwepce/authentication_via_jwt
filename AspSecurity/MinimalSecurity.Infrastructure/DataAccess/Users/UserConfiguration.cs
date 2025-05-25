using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalSecurity.Domain.Entities;

namespace MinimalSecurity.Infrastructure.DataAccess.Users;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure( EntityTypeBuilder<User> builder )
    {
        builder.ToTable( nameof( User ) )
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
    }
}
