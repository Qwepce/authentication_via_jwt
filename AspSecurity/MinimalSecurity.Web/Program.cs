using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Extensions.Options;
using MinimalSecurity.Application.Bindings;
using MinimalSecurity.Infrastructure.Bindings;
using MinimalSecurity.Infrastructure.Jwt;
using MinimalSecurity.Web.Bindings;

var builder = WebApplication.CreateBuilder( args );

builder.Services.Configure<JwtOptions>( builder.Configuration.GetSection( nameof( JwtOptions ) ) );

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationLayerBindings();
builder.Services.AddInfrastructureBindings( builder.Configuration );

builder.Services.AddApiAuthentication( builder.Configuration );

builder.Services.AddRouting( options =>
{
    options.LowercaseUrls = true;
} );

var app = builder.Build();

if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCookiePolicy( new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
} );

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
