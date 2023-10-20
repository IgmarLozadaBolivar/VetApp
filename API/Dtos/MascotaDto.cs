using Domain.Entities;
using NodaTime;
namespace API.Dtos;

public class MascotaDto : BaseEntity
{

    public int IdPropietarioFK { get; set; }
    public int IdEspecieFK { get; set; }
    public int IdRazaFK { get; set; }
    public string Nombre { get; set; }
    public LocalDate FechaNac { get; set; }
}