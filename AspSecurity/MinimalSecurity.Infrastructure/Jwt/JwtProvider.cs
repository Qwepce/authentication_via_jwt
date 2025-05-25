using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MinimalSecurity.Application.Interfaces;
using MinimalSecurity.Domain.Entities;

namespace MinimalSecurity.Infrastructure.Jwt;
public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;

    public JwtProvider( IOptions<JwtOptions> options )
    {
        _options = options.Value;
    }
    public string GenerateToken( User user )
    {
        Claim[] claims = [ new( "userId", user.Id.ToString() ) ];

        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey( Encoding.UTF8.GetBytes( _options.SecretKey ) ),
            SecurityAlgorithms.HmacSha256 );

        JwtSecurityToken token = new(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours( _options.ExpiresHours ) );

        string tokenValue = new JwtSecurityTokenHandler().WriteToken( token );

        return tokenValue;
    }
}
