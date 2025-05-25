using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MinimalSecurity.Infrastructure.Jwt;

namespace MinimalSecurity.Web.Bindings;

public static class WebLayerBindings
{
    public static void AddApiAuthentication( this IServiceCollection services, IConfiguration configuration )
    {
        JwtOptions jwtOptions = configuration.GetSection( nameof( JwtOptions ) ).Get<JwtOptions>();

        services.AddAuthentication( JwtBearerDefaults.AuthenticationScheme )
            .AddJwtBearer( options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( jwtOptions.SecretKey ) )
                };

                options.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies[ "chto-za-kuka" ];

                        return Task.CompletedTask;
                    }
                };
            } );

        services.AddAuthorization();
    }
}
