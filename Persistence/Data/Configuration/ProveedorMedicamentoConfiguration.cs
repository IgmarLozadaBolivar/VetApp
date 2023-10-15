using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class ProveedorMedicamentoConfiguration : IEntityTypeConfiguration<ProveedorMedicamento>
{
    public void Configure(EntityTypeBuilder<ProveedorMedicamento> builder)
    {
        builder.ToTable("Proveedor Medicamento");

        builder.HasKey(e => e.IdMedicamentoFK);
        builder.HasKey(e => e.IdProveedorFK);

        builder.Property(f => f.IdMedicamentoFK)
        .IsRequired()
        .HasMaxLength(3);

        builder.Property(f => f.IdProveedorFK)
        .IsRequired()
        .HasMaxLength(3);

        builder.HasOne(p => p.Medicamento)
        .WithMany(p => p.ProveedorMedicamentos)
        .HasForeignKey(p => p.IdMedicamentoFK);

        builder.HasOne(p => p.Proveedor)
        .WithMany(p => p.ProveedorMedicamentos)
        .HasForeignKey(p => p.IdProveedorFK);
    }
}