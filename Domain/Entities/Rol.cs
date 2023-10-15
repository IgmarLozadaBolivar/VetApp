namespace Domain.Entities;

public class Rol : BaseEntity
{
    public string Nombre { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<UserRol> UserRols { get; set; }
}