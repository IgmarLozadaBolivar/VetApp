using Domain.Entities;
namespace API.Dtos;

public class MascotaDto : BaseEntity
{

    public int IdPropietarioFK { get; set; }
    public int IdEspecieFK { get; set; }
    public int IdRazaFK { get; set; }
    public string Nombre { get; set; }
    public string FechaNac { get; set; }
}