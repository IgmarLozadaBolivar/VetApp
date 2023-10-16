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
        .HasDefaultValueSql("substring(encode(gen_random_uuid()::uuid, 'hex'), 1, 7)");

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

        builder.HasOne(p => p.Medicamento)
        .WithMany(p => p.DetalleMovimientos)
        .HasForeignKey(p => p.IdMedicamentoFK);

        builder.HasOne(p => p.MovimientoMedicamento)
        .WithMany(p => p.DetalleMovimientos)
        .HasForeignKey(p => p.IdMovMedFK);
    }
}