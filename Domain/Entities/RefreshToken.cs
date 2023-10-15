namespace Domain.Entities;

public class RefreshToken : BaseEntity
{
    public int IdUserFK { get; set; }
    public User User { get; set; }
    public string Token { get; set; }
    public string TokenRefresh { get; set; }
    public DateTime Expires { get; set; }
    public bool IsExpired => DateTime.UtcNow >= Expires;
    public DateTime Created { get; set; }
    public DateTime? Revoked { get; set; }
    public bool IsActive => Revoked == null && !IsExpired;
}