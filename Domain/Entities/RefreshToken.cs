using NodaTime;

namespace Domain.Entities;

public class RefreshToken : BaseEntity
{
    public int IdUserFK { get; set; }
    public User User { get; set; }
    public string Token { get; set; }
    public LocalDateTime Expires { get; set; }
    public bool IsExpired
    {
        get
        {
            var tzdbZone = DateTimeZoneProviders.Tzdb.GetSystemDefault();
            var zonedDateTime = Expires.InZoneLeniently(tzdbZone);
            var currentInstant = SystemClock.Instance.GetCurrentInstant();
            return currentInstant >= zonedDateTime.ToInstant();
        }
    }
    public LocalDateTime Created { get; set; }
}