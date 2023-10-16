namespace Domain.Entities;

public class UserRol
{
    public string IdUserFK { get; set; }
    public User User { get; set; }
    public string IdRolFK { get; set; }
    public Rol Rol { get; set; }
}