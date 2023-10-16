using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>
{
    public void Configure(EntityTypeBuilder<Veterinario> builder)
    {
        builder.ToTable("Veterinario");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

        builder.Property(f => f.Nombre)
        .IsRequired()
        .HasColumnName("Nombre")
        .HasComment("Nombre del veterinario")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.Property(f => f.Email)
        .IsRequired()
        .HasColumnName("Email")
        .HasComment("Correo electronico del veterinario")
        .HasColumnType("varchar")
        .HasMaxLength(150);

        builder.Property(f => f.Telefono)
        .IsRequired()
        .HasColumnName("Telefono")
        .HasComment("Telefono del veterinario")
        .HasColumnType("varchar")
        .HasMaxLength(30);

        builder.Property(f => f.Especialidad)
        .IsRequired()
        .HasColumnName("Especialidad")
        .HasComment("Especialidad del veterinario")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.HasOne(p => p.User)
        .WithMany(p => p.Veterinarios)
        .HasForeignKey(p => p.IdUserFK);
    }
}