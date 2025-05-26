using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalSecurity.Application.Interfaces;
using MinimalSecurity.Web.Contracts;

namespace MinimalSecurity.Web.Controllers;

[ApiController]
[Route( "api" )]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController( IUserService userService )
    {
        _userService = userService;
    }

    /// TEST METHODS TEST METHODS TEST METHODS TEST METHODS TEST METHODS TEST METHODS TEST METHODS TEST METHODS TEST METHODS

    [Authorize( "ReadPolicy" )]
    [HttpGet( "get" )]
    public async Task<IActionResult> SpecificGetEndpoint()
    {
        string result = await Task.FromResult( "This endpoint requires default policy in JWT-token claims" );

        return Ok( result );
    }

    [Authorize( "UpdatePolicy" )]
    [HttpPut( "put" )]
    public async Task<IActionResult> SpecificPutEndpoint()
    {

        string result = await Task.FromResult( "This endpoint requires update policy in JWT-token claims" );

        return Ok( result );
    }

    [Authorize( "CreatePolicy" )]
    [HttpPost( "create" )]
    public async Task<IActionResult> SpecificPostEndpoint()
    {

        string result = await Task.FromResult( "This endpoint requires create policy in JWT-token claims" );

        return Ok( result );
    }

    [Authorize( "DeletePolicy" )]
    [HttpDelete( "delete" )]
    public async Task<IActionResult> SpecificDeleteEndpoint()
    {

        string result = await Task.FromResult( "This endpoint requires delete policy in JWT-token claims" );

        return Ok( result );
    }

    /// TEST METHODS TEST METHODS TEST METHODS TEST METHODS TEST METHODS TEST METHODS TEST METHODS TEST METHODS TEST METHODS

    [HttpPost( "register" )]
    public async Task<IActionResult> RegisterUser( [FromBody] RegisterUserRequest request )
    {
        try
        {
            await _userService.Register( request.Username, request.Email, request.Password );
            return Ok();
        }
        catch ( InvalidOperationException ex )
        {
            return BadRequest( new { ex.Message } );
        }
    }

    [HttpPost( "login" )]
    public async Task<IActionResult> Login( [FromBody] LoginUserRequest request )
    {
        try
        {
            string token = await _userService.Login( request.Email, request.Password );
            HttpContext.Response.Cookies.Append( "chto-za-kuka", token );

            return Ok();
        }
        catch ( Exception ex )
        {
            return BadRequest( new { ex.Message } );
        }
    }
}
