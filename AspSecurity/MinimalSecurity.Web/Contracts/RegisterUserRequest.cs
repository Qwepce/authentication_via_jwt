using System.ComponentModel.DataAnnotations;

namespace MinimalSecurity.Web.Contracts;

public class RegisterUserRequest
{
    [Required( ErrorMessage = "Field is required" )]
    public string Username { get; init; }

    [Required( ErrorMessage = "Field is required" )]
    public string Password { get; init; }

    [Required( ErrorMessage = "Field is required" )]
    public string Email { get; init; }
}
