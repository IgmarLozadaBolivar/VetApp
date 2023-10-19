using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class TratamientoMedicoRepo : GenericRepo<TratamientoMedico>, ITratamientoMedico
{
    protected readonly DbAppContext _context;

    public TratamientoMedicoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TratamientoMedico>> GetAllAsync()
    {
        return await _context.TratamientoMedicos
            .Include(p => p.Citas)
            .Include(p => p.Medicamentos)
            .ToListAsync();
    }

    public override async Task<TratamientoMedico> GetByIdAsync(int id)
    {
        return await _context.TratamientoMedicos
        .Include(p => p.Citas)
        .Include(p => p.Medicamentos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task LoadCitasAsync(TratamientoMedico tratamientoMedico)
    {
        await _context.Entry(tratamientoMedico)
            .Reference(p => p.Citas)
            .LoadAsync();
    }

    public async Task LoadMedicamentosAsync(TratamientoMedico tratamientoMedico)
    {
        await _context.Entry(tratamientoMedico)
            .Reference(p => p.Medicamentos)
            .LoadAsync();
    }
}