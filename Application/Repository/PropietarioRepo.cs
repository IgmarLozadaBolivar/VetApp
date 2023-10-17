using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class PropietarioRepo : GenericRepo<Propietario>, IPropietario
{
    protected readonly DbAppContext _context;

    public PropietarioRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Propietario>> GetAllAsync()
    {
        return await _context.Propietarios
            .Include(p => p.Mascotas)
            .ToListAsync();
    }

    public override async Task<Propietario> GetByIdAsync(string id)
    {
        return await _context.Propietarios
        .Include(p => p.Mascotas)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<object> MascotasConPropietarios()
    {
        var consulta = from p in _context.Propietarios
                       select new
                       {
                           Nombre = p.Nombre,
                           Email = p.Email,
                           Telefono = p.Telefono,
                           Mascotas = (from m in _context.Mascotas
                                       where m.IdPropietarioFK == p.Id
                                       select new
                                       {
                                           NombreMascota = m.Nombre,
                                           FechaNacimiento = m.FechaNac
                                       }).ToList()
                       };

        var propietariosConMascotas = await consulta.ToListAsync();
        return propietariosConMascotas;
    }

    public async Task<object> MascotasGoldenRetriever()
    {
        var consulta = from p in _context.Propietarios
                       select new
                       {
                           nombre = p.Nombre,
                           email = p.Email,
                           telefono = p.Telefono,
                           mascotas = (from m in _context.Mascotas
                                       join r in _context.Razas on m.IdRazaFK equals r.Id
                                       where r.Nombre == "Golden Retriver"
                                       where m.IdPropietarioFK == p.Id
                                       select new
                                       {
                                           nombre = m.Nombre,
                                           FechaNacimiento = m.FechaNac,
                                           Raza = r.Nombre
                                       }).ToList()
                       };

        var mascotasGoldenRetriever = await consulta.ToListAsync();
        return mascotasGoldenRetriever;
    }

    /* public async Task LoadUsersAsync(Propietario propietario)
    {
        await _context.Entry(propietario)
            .Reference(p => p.Users)
            .LoadAsync();
    } */

    public async Task LoadMascotasAsync(string propietarioId)
    {
        var mascotas = await _context.Propietarios
                .Include(g => g.Mascotas)
                .FirstOrDefaultAsync(g => g.Id == propietarioId);

        if (mascotas != null)
        { }
    }

    public async Task LoadMovimientoMedicamentosAsync(string propietarioId)
    {
        var movimientoMedicamentos = await _context.Propietarios
                .Include(g => g.MovimientoMedicamentos)
                .FirstOrDefaultAsync(g => g.Id == propietarioId);

        if (movimientoMedicamentos != null)
        { }
    }
}
