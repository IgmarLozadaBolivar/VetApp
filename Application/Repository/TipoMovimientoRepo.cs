using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class TipoMovimientoRepo : GenericRepo<TipoMovimiento>, ITipoMovimiento
{
    protected readonly DbAppContext _context;

    public TipoMovimientoRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoMovimiento>> GetAllAsync()
    {
        return await _context.TipoMovimientos
            .Include(p => p.MovimientoMedicamentos)
            .ToListAsync();
    }

    public override async Task<TipoMovimiento> GetByIdAsync(int id)
    {
        return await _context.TipoMovimientos
        .Include(p => p.MovimientoMedicamentos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoMovimiento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.TipoMovimientos as IQueryable<TipoMovimiento>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Descripcion.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.MovimientoMedicamentos)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return (totalRegistros, registros);
    }
}