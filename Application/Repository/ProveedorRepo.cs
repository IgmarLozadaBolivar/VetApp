using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;

public class ProveedorRepo : GenericRepo<Proveedor>, IProveedor
{
    protected readonly DbAppContext _context;

    public ProveedorRepo(DbAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Proveedores
            .ToListAsync();
    }

    public override async Task<Proveedor> GetByIdAsync(int id)
    {
        return await _context.Proveedores
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<object> MedicamentosPorProveedor()
    {
        var medicamentoProveedor = from m in _context.Medicamentos
                                   select new
                                   {
                                       nombre = m.Nombre,
                                       proveedores = (from mp in _context.ProveedorMedicamentos
                                                      join me in _context.Medicamentos on mp.IdMedicamentoFK equals me.Id
                                                      join p in _context.Proveedores on mp.IdProveedorFK equals p.Id
                                                      where m.Id == mp.IdMedicamentoFK
                                                      select new
                                                      {
                                                          nombre = p.Nombre,
                                                      }).ToList()
                                   };

        var proveedorMedicamento = await medicamentoProveedor.ToListAsync();
        return proveedorMedicamento;
    }

    public override async Task<(int totalRegistros, IEnumerable<Proveedor> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Proveedores as IQueryable<Proveedor>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
            query = query.Where(p => p.Direccion.ToLower().Contains(search));
            query = query.Where(p => p.Telefono.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return (totalRegistros, registros);
    }
}