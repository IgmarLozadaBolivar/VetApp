using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DbAppContext context;
    private VeterinarioRepo _veterinarios;
    private MedicamentoRepo _medicamentos;
    private MascotaRepo _mascotas;
    private PropietarioRepo _propietarios;
    private MovimientoMedicamentoRepo _movimientoMedicamentos;
    private ProveedorRepo _proveedores;
    private CitaRepo _citas;
    private DetalleMovimientoRepo _detalleMovimiento;
    private EspecieRepo _especies;
    private LaboratorioRepo _laboratorios;
    private RazaRepo _razas;
    private TipoMovimientoRepo _tipoMovimientos;
    private TratamientoMedicoRepo __tratamientoMedicos;
    private UserRepo _users;

    public UnitOfWork(DbAppContext _context)
    {
        context = _context;
    }

    public IVeterinario Veterinarios
    {
        get
        {
            if (_veterinarios == null)
            {
                _veterinarios = new VeterinarioRepo(context);
            }
            return _veterinarios;
        }
    }

    public IMedicamento Medicamentos
    {
        get
        {
            if (_medicamentos == null)
            {
                _medicamentos = new MedicamentoRepo(context);
            }
            return _medicamentos;
        }
    }

    public IMascota Mascotas
    {
        get
        {
            if (_mascotas == null)
            {
                _mascotas = new MascotaRepo(context);
            }
            return _mascotas;
        }
    }

    public IPropietario Propietarios
    {
        get
        {
            if (_propietarios == null)
            {
                _propietarios = new PropietarioRepo(context);
            }
            return _propietarios;
        }
    }

    public IMovimientoMedicamento MovimientoMedicamentos
    {
        get
        {
            if (_movimientoMedicamentos == null)
            {
                _movimientoMedicamentos = new MovimientoMedicamentoRepo(context);
            }
            return _movimientoMedicamentos;
        }
    }

    public IProveedor Proveedores
    {
        get
        {
            if (_proveedores == null)
            {
                _proveedores = new ProveedorRepo(context);
            }
            return _proveedores;
        }
    }

    public ICita Citas
    {
        get
        {
            if (_citas == null)
            {
                _citas = new CitaRepo(context);
            }
            return _citas;
        }
    }

    public IDetalleMovimiento DetalleMovimientos
    {
        get
        {
            if (_detalleMovimiento == null)
            {
                _detalleMovimiento = new DetalleMovimientoRepo(context);
            }
            return _detalleMovimiento;
        }
    }

    public IEspecie Especies
    {
        get
        {
            if (_especies == null)
            {
                _especies = new EspecieRepo(context);
            }
            return _especies;
        }
    }

    public ILaboratorio Laboratorios
    {
        get
        {
            if (_laboratorios == null)
            {
                _laboratorios = new LaboratorioRepo(context);
            }
            return _laboratorios;
        }
    }

    public IRaza Razas
    {
        get
        {
            if (_razas == null)
            {
                _razas = new RazaRepo(context);
            }
            return _razas;
        }
    }

    public ITipoMovimiento TipoMovimientos
    {
        get
        {
            if (_tipoMovimientos == null)
            {
                _tipoMovimientos = new TipoMovimientoRepo(context);
            }
            return _tipoMovimientos;
        }
    }

    public ITratamientoMedico TratamientoMedicos
    {
        get
        {
            if (__tratamientoMedicos == null)
            {
                __tratamientoMedicos = new TratamientoMedicoRepo(context);
            }
            return __tratamientoMedicos;
        }
    }

    public IUser Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepo(context);
            }
            return _users;
        }
    }

    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}