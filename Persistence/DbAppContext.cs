using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.NodaTime;
namespace Persistence;

public class DbAppContext : DbContext
{
    public DbAppContext(DbContextOptions<DbAppContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<UserRol> UserRols { get; set; }
    public DbSet<Veterinario> Veterinarios { get; set; }
    public DbSet<Propietario> Propietarios { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Especie> Especies { get; set; }
    public DbSet<Raza> Razas { get; set; }
    public DbSet<Mascota> Mascotas { get; set; }
    public DbSet<TipoMovimiento> TipoMovimientos { get; set; }
    public DbSet<DetalleMovimiento> DetalleMovimientos { get; set; }
    public DbSet<MovimientoMedicamento> MovimientoMedicamentos { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<TratamientoMedico> TratamientoMedicos { get; set; }
    public DbSet<Cita> Citas { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<ProveedorMedicamento> ProveedorMedicamentos { get; set; }
    public DbSet<Laboratorio> Laboratorios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=VetDb;Username=postgres;Password=1122809631", npgsqlOptions =>
        {
            npgsqlOptions.UseNodaTime();
        });
    }
}