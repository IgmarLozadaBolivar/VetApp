using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshToken");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasDefaultValueSql("substring(encode(gen_random_uuid()::uuid, 'hex'), 1, 7)");

        builder.Property(f => f.Token)
        .IsRequired()
        .HasColumnName("Token")
        .HasComment("Token del usuario")
        .HasColumnType("varchar(150)")
        .HasMaxLength(150);

        builder.Property(f => f.Expires)
        .IsRequired()
        .HasColumnName("Expires")
        .HasComment("Expiracion del token");

        builder.Property(f => f.Created)
        .IsRequired()
        .HasColumnName("Created")
        .HasComment("Creacion del token");

        builder.Property(f => f.Revoked)
        .IsRequired()
        .HasColumnName("Revoked")
        .HasComment("Revocacion del token");
    }
}