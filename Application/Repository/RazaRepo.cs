using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class RazaRepo : GenericRepo<Raza>, IRaza
{
    protected readonly DbAppContext _context;

    public RazaRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Raza>> GetAllAsync()
    {
        return await _context.Razas
            .Include(p => p.Mascotas)
            .Include(p => p.Especies)
            .ToListAsync();
    }

    public override async Task<Raza> GetByIdAsync(string id)
    {
        return await _context.Razas
        .Include(p => p.Mascotas)
        .Include(p => p.Especies)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task LoadEspeciesAsync(Raza raza)
    {
        await _context.Entry(raza)
            .Reference(p => p.Especies)
            .LoadAsync();
    }

    public async Task LoadMascotasAsync(string razaId)
    {
        var mascotas = await _context.Razas
                .Include(g => g.Mascotas)
                .FirstOrDefaultAsync(g => g.Id == razaId);

        if (mascotas != null)
        { }
    }
}