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

    public override async Task<Medicamento> GetByIdAsync(int id)
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

    public virtual async Task<(int totalRegistros, object registros)> MedicamentosLaboratoriosGenfar(int pageIndez, int pageSize, string search)
    {
        var query =
            (from l in _context.Laboratorios
             where l.Nombre.Contains("Genfar")
             select new
             {
                 Nombre = l.Nombre,
                 Direccion = l.Direccion,
                 Telefono = l.Telefono
             }).Distinct();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Nombre);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
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