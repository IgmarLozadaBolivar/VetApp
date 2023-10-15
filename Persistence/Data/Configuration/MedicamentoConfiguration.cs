using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
{
    public void Configure(EntityTypeBuilder<Medicamento> builder)
    {
        builder.ToTable("Medicamento");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasMaxLength(3);

        builder.Property(f => f.Nombre)
        .IsRequired()
        .HasColumnName("Nombre")
        .HasComment("Nombre del medicamento")
        .HasColumnType("varchar(50)")
        .HasMaxLength(50);

        builder.Property(f => f.Stock)
        .IsRequired()
        .HasColumnName("StockDisponible")
        .HasComment("Cantidad disponible del medicamento")
        .HasColumnType("int");

        builder.Property(f => f.Precio)
        .IsRequired()
        .HasColumnName("Precio")
        .HasComment("Precio del medicamento")
        .HasColumnType("decimal");

        builder.HasOne(p => p.Laboratorio)
        .WithMany(p => p.Medicamentos)
        .HasForeignKey(p => p.IdLaboratorioFK);
    }
}