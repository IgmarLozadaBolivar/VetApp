using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
{
    public void Configure(EntityTypeBuilder<Mascota> builder)
    {
        builder.ToTable("Mascota");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasMaxLength(3);

        builder.Property(f => f.Nombre)
        .IsRequired()
        .HasColumnName("Nombre")
        .HasComment("Nombre de la mascota")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.Property(f => f.FechaNac)
        .IsRequired()
        .HasColumnName("Fecha Nacimiento")
        .HasComment("Fecha de nacimiento de la mascota");

        builder.HasOne(p => p.Propietarios)
        .WithMany(p => p.Mascotas)
        .HasForeignKey(p => p.IdPropietarioFK);

        builder.HasOne(p => p.Razas)
        .WithMany(p => p.Mascotas)
        .HasForeignKey(p => p.IdRazaFK);
    }
}