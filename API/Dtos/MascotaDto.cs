using Domain.Entities;
namespace API.Dtos;

public class MascotaDto : BaseEntity
{

    public string IdPropietarioFK { get; set; }
    public string IdEspecieFK { get; set; }
    public string IdRazaFK { get; set; }
    public string Nombre { get; set; }
    public string FechaNac { get; set; }
}