namespace MinimalSecurity.Domain.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string HashedPassword { get; set; }
    public string Email { get; set; }

    public ICollection<RoleEntity> Roles { get; set; } = [];

    public UserEntity(
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
