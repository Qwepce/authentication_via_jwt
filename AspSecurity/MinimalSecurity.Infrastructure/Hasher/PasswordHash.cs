using MinimalSecurity.Application.Interfaces;

namespace MinimalSecurity.Infrastructure.Hasher;
public class PasswordHash : IPasswordHash
{
    public string GenerateHash( string password )
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword( password );
    }

    public bool Verify( string password, string hashedPassword )
    {
        return BCrypt.Net.BCrypt.EnhancedVerify( password, hashedPassword );
    }
}
