using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalSecurity.Application.Interfaces;
using MinimalSecurity.Web.Contracts;
using Swashbuckle.AspNetCore.Annotations;

namespace MinimalSecurity.Web.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController( IUserService userService )
    {
        _userService = userService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetInfo()
    {
        string message = "If you are here, than u are authenticated user. Congrats!";

        string result = await Task.FromResult( message );

        return Ok( result );
    }

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
