using MinimalSecurity.Domain.Entities;
using MinimalSecurity.Domain.Enums;

namespace MinimalSecurity.Application.Interfaces;
public interface IUserRepository
{
    Task AddAsync( UserEntity user );
    Task<UserEntity> GetByEmail( string email );
    Task<HashSet<Permission>> GetUserPermissions( Guid userId );
}
