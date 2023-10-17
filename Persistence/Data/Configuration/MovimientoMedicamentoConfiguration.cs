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
        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

        builder.Property(f => f.Fecha)
        .IsRequired()
        .HasColumnName("Fecha")
        .HasComment("Fecha del movimiento");

        builder.Property(f => f.Total)
        .IsRequired()
        .HasColumnName("Total")
        .HasComment("Total del movimiento")
        .HasColumnType("int");

        builder.HasOne(p => p.Medicamentos)
        .WithMany(p => p.MovimientoMedicamentos)
        .HasForeignKey(p => p.IdMedicamentoFK);

        builder.HasOne(p => p.Propietarios)
        .WithMany(p => p.MovimientoMedicamentos)
        .HasForeignKey(p => p.IdPropietarioFK);

        builder.HasOne(p => p.TipoMovimientos)
        .WithMany(p => p.MovimientoMedicamentos)
        .HasForeignKey(p => p.IdTipoMovimientoFK);
    }
}