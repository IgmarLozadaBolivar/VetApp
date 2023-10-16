using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class PropietarioConfiguration : IEntityTypeConfiguration<Propietario>
{
    public void Configure(EntityTypeBuilder<Propietario> builder)
    {
        builder.ToTable("Propietario");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasDefaultValueSql("substring(encode(gen_random_uuid()::uuid, 'hex'), 1, 7)");

        builder.Property(f => f.Nombre)
        .IsRequired()
        .HasColumnName("Nombre")
        .HasComment("Nombre del propietario")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.Property(f => f.Email)
        .IsRequired()
        .HasColumnName("Email")
        .HasComment("Correo electronico del propietario")
        .HasColumnType("varchar")
        .HasMaxLength(150);

        builder.Property(f => f.Telefono)
        .IsRequired()
        .HasColumnName("Telefono")
        .HasComment("Telefono del propietario")
        .HasColumnType("varchar")
        .HasMaxLength(30);

        builder.HasOne(p => p.User)
        .WithMany(p => p.Propietarios)
        .HasForeignKey(p => p.IdUserFK);
    }
}