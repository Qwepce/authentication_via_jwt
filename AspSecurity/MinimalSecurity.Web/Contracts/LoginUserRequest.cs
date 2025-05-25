using System.ComponentModel.DataAnnotations;

namespace MinimalSecurity.Web.Contracts;

public class LoginUserRequest
{
    [Required( ErrorMessage = "Field is required" )]
    public string Email { get; init; }

    [Required( ErrorMessage = "Field is required" )]
    public string Password { get; init; }
}
