using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class EspecieRepo : GenericRepo<Especie>, IEspecie
{
    protected readonly DbAppContext _context;

    public EspecieRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Especie>> GetAllAsync()
    {
        return await _context.Especies
            .Include(p => p.Razas)
            .Include(p => p.Mascotas)
            .ToListAsync();
    }

    public override async Task<Especie> GetByIdAsync(string id)
    {
        return await _context.Especies
        .Include(p => p.Razas)
        .Include(p => p.Mascotas)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task LoadMascotasAsync(string mascotaId)
    {
        var especie = await _context.Especies
                .Include(g => g.Mascotas)
                .FirstOrDefaultAsync(g => g.Id == mascotaId);

            if (especie != null)
            {}
    }

    public async Task LoadRazasAsync(string razaId)
    {
        var genero = await _context.Especies
                .Include(g => g.Razas)
                .FirstOrDefaultAsync(g => g.Id == razaId);

            if (genero != null)
            {}
    }
}