using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class CitaConfiguration : IEntityTypeConfiguration<Cita>
{
    public void Configure(EntityTypeBuilder<Cita> builder)
    {
        builder.ToTable("Cita");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasMaxLength(3);

        builder.Property(f => f.Fecha)
        .IsRequired()
        .HasColumnName("Fecha")
        .HasComment("Fecha de la cita")
        .HasColumnType("date");

        builder.Property(f => f.Hora)
        .IsRequired()
        .HasColumnName("Hora")
        .HasComment("Hora de la cita")
        .HasColumnType("time");

        builder.Property(f => f.Motivo)
        .IsRequired()
        .HasColumnName("Motivo")
        .HasComment("Motivo de la cita")
        .HasColumnType("varchar")
        .HasMaxLength(150);

        builder.HasOne(p => p.Mascotas)
        .WithMany(p => p.Citas)
        .HasForeignKey(p => p.IdMascotaFK);

        builder.HasOne(p => p.Veterinarios)
        .WithMany(p => p.Citas)
        .HasForeignKey(p => p.IdVeterinarioFK);
    }
}