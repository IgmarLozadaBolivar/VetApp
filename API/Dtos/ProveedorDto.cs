using Domain.Entities;
namespace API.Dtos;

public class ProveedorDto : BaseEntity
{
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public int IdUserFK { get; set; }
}