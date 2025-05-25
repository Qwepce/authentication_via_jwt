using MinimalSecurity.Domain.Entities;

namespace MinimalSecurity.Application.Interfaces;
public interface IUserRepository
{
    Task AddAsync( User user );
    Task<User> GetByEmail( string email );
}
