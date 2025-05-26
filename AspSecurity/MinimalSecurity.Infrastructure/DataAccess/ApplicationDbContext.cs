using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MinimalSecurity.Domain.Entities;
using MinimalSecurity.Infrastructure.Authentication.Helpers;
using MinimalSecurity.Infrastructure.DataAccess.Permissions;
using MinimalSecurity.Infrastructure.DataAccess.RolePermissions;
using MinimalSecurity.Infrastructure.DataAccess.Roles;
using MinimalSecurity.Infrastructure.DataAccess.Users;

namespace MinimalSecurity.Infrastructure.DataAccess;
public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options,
    IOptions<AuthorizationOptions> authOptions )
    : DbContext( options )
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        base.OnConfiguring( optionsBuilder );
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfiguration( new RolePermissionConfiguration( authOptions.Value ) );
        modelBuilder.ApplyConfiguration( new UserEntityConfiguration() );
        modelBuilder.ApplyConfiguration( new RoleEntityConfiguration() );
        modelBuilder.ApplyConfiguration( new PermissionEntityConfiguration() );
    }
}
