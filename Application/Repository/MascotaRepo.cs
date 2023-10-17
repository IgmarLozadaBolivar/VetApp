using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class MascotaRepo : GenericRepo<Mascota>, IMascota
{
    protected readonly DbAppContext _context;

    public MascotaRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Mascota>> GetAllAsync()
    {
        return await _context.Mascotas
            .Include(p => p.Especies)
            .Include(u => u.Razas)
            .ToListAsync();
    }

    public override async Task<Mascota> GetByIdAsync(string id)
    {
        return await _context.Mascotas
        .Include(p => p.Especies)
        .Include(u => u.Razas)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Mascota>> MascotasEspeciesFelinas()
    {
        return await _context.Mascotas
            .Include(p => p.Especies)
            .Where(p => p.Especies.Nombre == "Felina")
            .ToListAsync();
    }

    public async Task<IEnumerable<Mascota>> MascotasVacunacionPrimerTrimestre2023()
    {
        DateOnly inicioTrimestre = new DateOnly(2023, 1, 1);
        DateOnly finTrimestre = new DateOnly(2023, 3, 31);

        var mascotasVacunacion = await _context.Citas
        .Where(c => c.Fecha >= inicioTrimestre && c.Fecha <= finTrimestre && c.Motivo == "Vacunacion")
        .Select(c => c.Mascotas)
        .Distinct()
        .ToListAsync();

        return mascotasVacunacion;
    }

    public async Task<object> EspeciesMascotas()
    {
        var especiesMascotas =
        from e in _context.Especies
        select new
        {
            nombre = e.Nombre,
            mascotas = (from m in _context.Mascotas
                        join r in _context.Razas on m.IdRazaFK equals r.Id
                        where m.IdRazaFK == r.Id
                        where r.IdEspecieFK == e.Id
                        select new
                        {
                            nombre = m.Nombre,
                            FechaNacimiento = m.FechaNac,
                            Raza = r.Nombre
                        }).ToList()
        };

        var especiesMascota = await especiesMascotas.ToListAsync();
        return especiesMascota;
    }

    public async Task<object> MascotaAtendidaPorVeterinario()
    {
        var mascotasAtendidas = 
        from e in _context.Citas 
        join v in _context.Veterinarios on e.IdVeterinarioFK equals v.Id
        select new
        {
            veterinario = v.Nombre,
            mascotas = (from c in _context.Citas 
                        join m in _context.Mascotas on c.IdMascotaFK equals m.Id
                        where c.IdVeterinarioFK == v.Id
                        select new
                        {
                            nombre = m.Nombre,
                            FechaNacimiento = m.FechaNac,
                        }).ToList()
        };

        var mascotaAtendida = await mascotasAtendidas.ToListAsync();
        return mascotaAtendida;
    }

    public async Task<object> RazasCantidadMascotas()
    {
        var mascotasPorRazas =
        from r in _context.Razas
        select new
        {
            nombre = r.Nombre,
            cantidad = _context.Mascotas.Distinct().Count(m => m.IdRazaFK == r.Id)
        };

        var mascotasPorRaza = await mascotasPorRazas.ToListAsync();
        return mascotasPorRaza;
    }

    public async Task LoadPropietariosAsync(Mascota mascota)
    {
        await _context.Entry(mascota)
            .Reference(p => p.Propietarios)
            .LoadAsync();
    }

    public async Task LoadEspeciesAsync(Mascota mascota)
    {
        await _context.Entry(mascota)
            .Reference(p => p.Especies)
            .LoadAsync();
    }

    public async Task LoadRazasAsync(Mascota mascota)
    {
        await _context.Entry(mascota)
            .Reference(p => p.Razas)
            .LoadAsync();
    }
}