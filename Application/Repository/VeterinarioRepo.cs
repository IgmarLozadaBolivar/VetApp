using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class VeterinarioRepo : GenericRepo<Veterinario>, IVeterinario
{
    protected readonly DbAppContext _context;

    public VeterinarioRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Veterinario>> GetAllAsync()
    {
        return await _context.Veterinarios
            .Include(p => p.Citas)
            .ToListAsync();
    }

    public override async Task<Veterinario> GetByIdAsync(int id)
    {
        return await _context.Veterinarios
        .Include(p => p.Citas)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Veterinario>> VeterinariosCirujanosVasculares()
    {
        return await _context.Veterinarios
            .Where(m => m.Especialidad == "Cirujano Vascular")
            .ToListAsync();
    }

    public async Task LoadCitasAsync(int veterinarioId)
    {
        var cita = await _context.Veterinarios
                .Include(g => g.Citas)
                .FirstOrDefaultAsync(g => g.Id == veterinarioId);

        if (cita != null)
        { }
    }
}