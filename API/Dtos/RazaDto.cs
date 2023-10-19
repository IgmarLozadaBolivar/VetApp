using Domain.Entities;
namespace API.Dtos;

public class RazaDto : BaseEntity
{
    public int IdEspecieFK { get; set; }
    public string Nombre { get; set; }
}