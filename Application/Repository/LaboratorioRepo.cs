using Domain.Entities;
using Domain.Interfaces;
using iText.Kernel.Colors;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class LaboratorioRepo : GenericRepo<Laboratorio>, ILaboratorio
{
    protected readonly DbAppContext _context;

    public LaboratorioRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Laboratorio>> GetAllAsync()
    {
        return await _context.Laboratorios
            .Include(p => p.Medicamentos)
            .ToListAsync();
    }

    public override async Task<Laboratorio> GetByIdAsync(string id)
    {
        return await _context.Laboratorios
        .Include(p => p.Medicamentos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task LoadMedicamentosAsync(string medicamentoId)
    {
        var medicamento = await _context.Laboratorios
                .Include(g => g.Medicamentos)
                .FirstOrDefaultAsync(g => g.Id == medicamentoId);

        if (medicamento != null)
        { }
    }
}