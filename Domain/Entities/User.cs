namespace Domain.Entities;

public class User : BaseEntity
{
    public string Mail { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public ICollection<Rol> Rols { get; set; } = new HashSet<Rol>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    public ICollection<UserRol> UserRols { get; set; }
}