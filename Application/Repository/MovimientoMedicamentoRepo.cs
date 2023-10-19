using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class MovimientoMedicamentoRepo : GenericRepo<MovimientoMedicamento>, IMovimientoMedicamento
{
    protected readonly DbAppContext _context;

    public MovimientoMedicamentoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MovimientoMedicamento>> GetAllAsync()
    {
        return await _context.MovimientoMedicamentos
            .Include(p => p.TipoMovimientos)
            .ToListAsync();
    }

    public override async Task<MovimientoMedicamento> GetByIdAsync(int id)
    {
        return await _context.MovimientoMedicamentos
        .Include(p => p.TipoMovimientos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<object> TotalCadaMovimiento()
    {

        var totalMovimiento = await (
            from d in _context.DetalleMovimientos
            join m in _context.MovimientoMedicamentos on d.IdMovMedFK equals m.Id

            select new
            {
                idMovMed = m.Id,
                tipoMovimiento = m.TipoMovimientos.Descripcion,
                total = d.Precio * d.Cantidad,
            }).Distinct()
            .ToListAsync();

        return totalMovimiento;
    }

    public async Task LoadTipoMovimientosAsync(MovimientoMedicamento movimientoMedicamento)
    {
        await _context.Entry(movimientoMedicamento)
            .Reference(p => p.TipoMovimientos)
            .LoadAsync();
    }
}