using Microsoft.EntityFrameworkCore;
using MinimalSecurity.Application.Interfaces;
using MinimalSecurity.Domain.Entities;

namespace MinimalSecurity.Infrastructure.DataAccess.Users;
public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository( ApplicationDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync( User user )
    {
        await _dbContext.Users.AddAsync( user );
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetByEmail( string email )
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync( u => u.Email == email );
    }
}
