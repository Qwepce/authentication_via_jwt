using Microsoft.EntityFrameworkCore;
using MinimalSecurity.Domain.Entities;
using MinimalSecurity.Infrastructure.DataAccess.Users;

namespace MinimalSecurity.Infrastructure.DataAccess;
public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options )
        : base( options )
    {
    }

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        base.OnConfiguring( optionsBuilder );
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfiguration( new UserConfiguration() );
    }
}
