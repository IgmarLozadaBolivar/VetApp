using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio>
{
    public void Configure(EntityTypeBuilder<Laboratorio> builder)
    {
        builder.ToTable("Laboratorio");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

        builder.Property(f => f.Nombre)
        .IsRequired()
        .HasColumnName("Nombre")
        .HasComment("Nombre del laboratorio")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.Property(f => f.Direccion)
        .IsRequired()
        .HasColumnName("Direccion")
        .HasComment("Direccion del laboratorio")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.Property(f => f.Telefono)
        .IsRequired()
        .HasColumnName("Telefono")
        .HasComment("Numero del telefono celular del laboratorio")
        .HasColumnType("varchar")
        .HasMaxLength(30);
    }
}