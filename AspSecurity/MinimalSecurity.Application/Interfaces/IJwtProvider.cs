using MinimalSecurity.Domain.Entities;

namespace MinimalSecurity.Application.Interfaces;
public interface IJwtProvider
{
    string GenerateToken( UserEntity user );
}
