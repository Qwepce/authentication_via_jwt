using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MinimalSecurity.Domain.Enums;
using MinimalSecurity.Infrastructure.Authentication;
using MinimalSecurity.Infrastructure.Jwt;

namespace MinimalSecurity.Web.Bindings;

public static class WebLayerBindings
{
    public static void AddApiAuthentication( this IServiceCollection services, IConfiguration configuration )
    {
        JwtOptions jwtOptions = configuration.GetSection( nameof( JwtOptions ) ).Get<JwtOptions>();

        services
            .AddAuthentication( options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            } )
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

        services.AddAuthorization( options =>
        {
            options.AddPolicy( "ReadPolicy", policy =>
            {
                policy.AddRequirements( new PermissionRequirement( [ Permission.Read ] ) );
            } );

            options.AddPolicy( "CreatePolicy", policy =>
            {
                policy.AddRequirements( new PermissionRequirement( [ Permission.Create ] ) );
            } );

            options.AddPolicy( "UpdatePolicy", policy =>
            {
                policy.AddRequirements( new PermissionRequirement( [ Permission.Update ] ) );
            } );

            options.AddPolicy( "DeletePolicy", policy =>
            {
                policy.AddRequirements( new PermissionRequirement( [ Permission.Delete ] ) );
            } );
        } );
    }
}
