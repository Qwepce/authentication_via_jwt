using MinimalSecurity.Domain.Enums;

namespace MinimalSecurity.Application.Interfaces;

public interface IPermissionService
{
    Task<HashSet<Permission>> GetPermissionsAsync( Guid userId );
}
