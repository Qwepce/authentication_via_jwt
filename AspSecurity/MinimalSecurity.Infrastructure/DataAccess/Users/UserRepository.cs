using Microsoft.EntityFrameworkCore;
using MinimalSecurity.Application.Interfaces;
using MinimalSecurity.Domain.Entities;
using MinimalSecurity.Domain.Enums;

namespace MinimalSecurity.Infrastructure.DataAccess.Users;
public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository( ApplicationDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync( UserEntity user )
    {
        RoleEntity roleEntity = await _dbContext.Roles
            .SingleOrDefaultAsync( r => r.Id == ( int )RoleEnum.User )
            ?? throw new InvalidOperationException();

        user.Roles = [ roleEntity ];

        await _dbContext.Users.AddAsync( user );
        await _dbContext.SaveChangesAsync();
    }

    public async Task<UserEntity> GetByEmail( string email )
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync( u => u.Email == email );
    }

    public async Task<HashSet<Permission>> GetUserPermissions( Guid userId )
    {
        List<ICollection<RoleEntity>> roles = await _dbContext.Users
            .AsNoTracking()
            .Include( u => u.Roles )
            .ThenInclude( r => r.Permissions )
            .Where( u => u.Id == userId )
            .Select( u => u.Roles )
            .ToListAsync();

        return roles
            .SelectMany( r => r )
            .SelectMany( r => r.Permissions )
            .Select( p => ( Permission )p.Id )
            .ToHashSet();
    }
}
