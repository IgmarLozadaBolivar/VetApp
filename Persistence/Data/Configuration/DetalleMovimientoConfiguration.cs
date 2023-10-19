using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class DetalleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>
{
    public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
    {
        builder.ToTable("DetalleMovimiento");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasMaxLength(3);

        builder.Property(f => f.Cantidad)
        .IsRequired()
        .HasColumnName("Cantidad")
        .HasComment("Cantidad del movimiento")
        .HasColumnType("int");

        builder.Property(f => f.Precio)
        .IsRequired()
        .HasColumnName("Precio")
        .HasComment("Precio del movimiento")
        .HasColumnType("decimal");

        builder.HasOne(p => p.Medicamentos)
        .WithMany(p => p.DetalleMovimientos)
        .HasForeignKey(p => p.IdMedicamentoFK);

        builder.HasOne(p => p.MovimientoMedicamentos)
        .WithMany(p => p.DetalleMovimientos)
        .HasForeignKey(p => p.IdMovMedFK);
    }
}