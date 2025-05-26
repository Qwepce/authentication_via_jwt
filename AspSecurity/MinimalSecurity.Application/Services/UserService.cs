using MinimalSecurity.Application.Interfaces;
using MinimalSecurity.Domain.Entities;

namespace MinimalSecurity.Application.Services;
public class UserService : IUserService
{
    private readonly IPasswordHash _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public UserService( IPasswordHash passwordHasher, IUserRepository userRepository, IJwtProvider jwtProvider )
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task Register( string username, string email, string password )
    {
        string hashedPassword = _passwordHasher.GenerateHash( password );
        UserEntity existedUser = await _userRepository.GetByEmail( email );
        if ( existedUser is not null )
        {
            throw new InvalidOperationException( $"User with email: {email} already exists" );
        }

        UserEntity user = new(
            username,
            hashedPassword,
            email );

        await _userRepository.AddAsync( user );
    }

    public async Task<string> Login( string email, string password )
    {
        UserEntity user = await _userRepository.GetByEmail( email );
        if ( user is null )
        {
            throw new InvalidOperationException( $"User with email {email} does not exists" );
        }

        bool resultOfVerification = _passwordHasher.Verify( password, user.HashedPassword );
        if ( !resultOfVerification )
        {
            throw new ArgumentException( "Uncorrect password" );
        }

        string token = _jwtProvider.GenerateToken( user );

        return token;
    }
}
