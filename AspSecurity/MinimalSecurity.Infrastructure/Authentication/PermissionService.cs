using MinimalSecurity.Application.Interfaces;
using MinimalSecurity.Domain.Enums;

namespace MinimalSecurity.Infrastructure.Authentication;

public class PermissionService : IPermissionService
{
    private readonly IUserRepository _userRepository;

    public PermissionService( IUserRepository userRepository )
    {
        _userRepository = userRepository;
    }

    public Task<HashSet<Permission>> GetPermissionsAsync( Guid userId )
    {
        return _userRepository.GetUserPermissions( userId );
    }
}