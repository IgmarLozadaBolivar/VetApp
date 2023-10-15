using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("Proveedor");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasMaxLength(3);

        builder.Property(f => f.Nombre)
        .IsRequired()
        .HasColumnName("Nombre")
        .HasComment("Nombre del proveedor")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.Property(f => f.Direccion)
        .IsRequired()
        .HasColumnName("Direccion")
        .HasComment("Direccion del proveedor")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.Property(f => f.Telefono)
        .IsRequired()
        .HasColumnName("Telefono")
        .HasComment("Telefono del proveedor")
        .HasColumnType("varchar")
        .HasMaxLength(30);

        builder.HasMany(p => p.Medicamentos)
               .WithMany(r => r.Proveedores)
               .UsingEntity<ProveedorMedicamento>(

                   j => j
                   .HasOne(pt => pt.Medicamento)
                   .WithMany(t => t.ProveedorMedicamentos)
                   .HasForeignKey(ut => ut.IdMedicamentoFK),

                   j => j
                   .HasOne(et => et.Proveedor)
                   .WithMany(et => et.ProveedorMedicamentos)
                   .HasForeignKey(el => el.IdProveedorFK),

                   j =>
                   {
                       j.ToTable("UserRol");
                       j.HasKey(t => new { t.IdProveedorFK, t.IdMedicamentoFK });

                   });

        builder.HasOne(p => p.User)
        .WithMany(p => p.Proveedores)
        .HasForeignKey(p => p.IdUserFK);
    }
}