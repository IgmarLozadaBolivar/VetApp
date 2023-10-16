using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class RazaConfiguration : IEntityTypeConfiguration<Raza>
{
    public void Configure(EntityTypeBuilder<Raza> builder)
    {
        builder.ToTable("Raza");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

        builder.Property(f => f.Nombre)
        .IsRequired()
        .HasColumnName("Nombre")
        .HasComment("Nombre de la raza")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.HasOne(p => p.Especie)
        .WithMany(p => p.Razas)
        .HasForeignKey(p => p.IdEspecieFK);
    }
}