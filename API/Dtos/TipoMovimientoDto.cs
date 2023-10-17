using Domain.Entities;
namespace API.Dtos;

public class TipoMovimientoDto : BaseEntity
{
    public string Descripcion { get; set; }
}