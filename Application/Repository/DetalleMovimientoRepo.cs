using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class DetalleMovimientoRepo : GenericRepo<DetalleMovimiento>, IDetalleMovimiento
{
    protected readonly DbAppContext _context;

    public DetalleMovimientoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DetalleMovimiento>> GetAllAsync()
    {
        return await _context.DetalleMovimientos
            .Include(p => p.Medicamentos)
            .Include(p => p.MovimientoMedicamentos)
            .ToListAsync();
    }

    public override async Task<DetalleMovimiento> GetByIdAsync(int id)
    {
        return await _context.DetalleMovimientos
        .Include(p => p.Medicamentos)
        .Include(p => p.MovimientoMedicamentos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task LoadMedicamentosAsync(DetalleMovimiento detalleMovimiento)
    {
        await _context.Entry(detalleMovimiento)
            .Reference(p => p.Medicamentos)
            .LoadAsync();
    }

    public async Task LoadMovimientoMedicamentosAsync(DetalleMovimiento detalleMovimiento)
    {
        await _context.Entry(detalleMovimiento)
            .Reference(p => p.MovimientoMedicamentos)
            .LoadAsync();
    }
}
