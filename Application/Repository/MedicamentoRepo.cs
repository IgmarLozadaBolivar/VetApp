using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class MedicamentoRepo : GenericRepo<Medicamento>, IMedicamento
{
    protected readonly DbAppContext _context;

    public MedicamentoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _context.Medicamentos
            .Include(p => p.Laboratorios)
            .ToListAsync();
    }

    public override async Task<Medicamento> GetByIdAsync(string id)
    {
        return await _context.Medicamentos
        .Include(p => p.Laboratorios)
        .FirstOrDefaultAsync(p => p.Id == id);
    }


    public async Task<IEnumerable<Medicamento>> MedicamentosLaboratoriosGenfar()
    {
        return await _context.Medicamentos
            .Include(p => p.Laboratorios)
            .Where(p => p.Laboratorios.Nombre == "Genfar")
            .ToListAsync();
    }

    public async Task<IEnumerable<Medicamento>> PrecioMayorA50k()
    {
        return await _context.Medicamentos
            .Where(p => p.Precio > 50000)
            .ToListAsync();
    }

    public async Task LoadLaboratoriosAsync(Medicamento medicamento)
    {
        await _context.Entry(medicamento)
            .Reference(p => p.Laboratorios)
            .LoadAsync();
    }
}