using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class CitaRepo : GenericRepo<Cita>, ICita
{
    protected readonly DbAppContext _context;

    public CitaRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cita>> GetAllAsync()
    {
        return await _context.Citas
            .Include(p => p.Mascotas)
            .Include(p => p.Veterinarios)
            .ToListAsync();
    }

    public override async Task<Cita> GetByIdAsync(int id)
    {
        return await _context.Citas
        .Include(p => p.Mascotas)
        .Include(p => p.Veterinarios)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task LoadMascotasAsync(Cita cita)
    {
        await _context.Entry(cita)
            .Reference(p => p.Mascotas)
            .LoadAsync();
    }

    public async Task LoadVeterinariosAsync(Cita cita)
    {
        await _context.Entry(cita)
            .Reference(p => p.Veterinarios)
            .LoadAsync();
    }
}