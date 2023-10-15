using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("Proveedor");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasMaxLength(3);

        builder.Property(f => f.Nombre)
        .IsRequired()
        .HasColumnName("Nombre")
        .HasComment("Nombre del proveedor")
        .HasColumnType("varchar(50)")
        .HasMaxLength(50);

        builder.Property(f => f.Direccion)
        .IsRequired()
        .HasColumnName("Direccion")
        .HasComment("Direccion del proveedor")
        .HasColumnType("varchar(50)")
        .HasMaxLength(50);

        builder.Property(f => f.Telefono)
        .IsRequired()
        .HasColumnName("Telefono")
        .HasComment("Telefono del proveedor")
        .HasColumnType("varchar(30)")
        .HasMaxLength(30);

        builder.HasOne(p => p.User)
        .WithMany(p => p.Proveedores)
        .HasForeignKey(p => p.IdUserFK);
    }
}