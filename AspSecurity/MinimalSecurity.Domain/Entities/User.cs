namespace MinimalSecurity.Domain.Entities;
public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string HashedPassword { get; set; }
    public string Email { get; set; }

    public User(
        string username,
        string hashedPassword,
        string email )
    {
        Id = Guid.NewGuid();
        Username = username;
        HashedPassword = hashedPassword;
        Email = email;
    }
}
