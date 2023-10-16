namespace Domain.Entities;

public class RefreshToken : BaseEntity
{
    public string IdUserFK { get; set; }
    public User User { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public bool IsExpired => DateTime.UtcNow >= Expires;
    public DateTime Created { get; set; }
}