namespace MinimalSecurity.Application.Interfaces;

public interface IPasswordHash
{
    string GenerateHash( string password );
    bool Verify( string password, string hashedPassword );
}