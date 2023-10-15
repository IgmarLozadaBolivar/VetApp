using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class MovimientoMedicamentoConfiguration : IEntityTypeConfiguration<MovimientoMedicamento>
{
    public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
    {
        builder.ToTable("MovimientoMedicamento");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasMaxLength(3);

        builder.Property(f => f.Fecha)
        .IsRequired()
        .HasColumnName("Fecha")
        .HasComment("Fecha del movimiento");

        builder.Property(f => f.Total)
        .IsRequired()
        .HasColumnName("Total")
        .HasComment("Total del movimiento")
        .HasColumnType("int");

        builder.HasOne(p => p.Medicamento)
        .WithMany(p => p.MovimientoMedicamentos)
        .HasForeignKey(p => p.IdMedicamentoFK);

        builder.HasOne(p => p.Propietario)
        .WithMany(p => p.MovimientoMedicamentos)
        .HasForeignKey(p => p.IdPropietarioFK);

        builder.HasOne(p => p.TipoMovimiento)
        .WithMany(p => p.MovimientoMedicamentos)
        .HasForeignKey(p => p.IdTipoMovimientoFK);
    }
}