using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class TratamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico>
{
    public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
    {
        builder.ToTable("TratamientoMedico");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasMaxLength(3);

        builder.Property(f => f.Dosis)
        .IsRequired()
        .HasColumnName("Dosis")
        .HasComment("Dosis del tratamiento medico")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.Property(f => f.DetalleConsumo)
        .IsRequired()
        .HasColumnName("DetalleConsumo")
        .HasComment("Detalles del consumo de la dosis")
        .HasColumnType("varchar")
        .HasMaxLength(150);

        builder.Property(f => f.Observacion)
        .IsRequired()
        .HasColumnName("Observacion")
        .HasComment("Observaciones del tratamiento medico")
        .HasColumnType("varchar")
        .HasMaxLength(150);

        builder.HasOne(p => p.Cita)
        .WithMany(p => p.TratamientoMedicos)
        .HasForeignKey(p => p.IdCitaFK);

        builder.HasOne(p => p.Medicamento)
        .WithMany(p => p.TratamientoMedicos)
        .HasForeignKey(p => p.IdMedicamentoFK);
    }
}