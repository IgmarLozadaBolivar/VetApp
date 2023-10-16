using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(e => e.Id);

        builder.Property(f => f.Id)
        .IsRequired()
        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

        builder.Property(f => f.Mail)
        .IsRequired()
        .HasColumnName("Mail")
        .HasComment("Correo del usuario")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.Property(f => f.Username)
        .IsRequired()
        .HasColumnName("Username")
        .HasComment("Nombre del usuario")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.Property(f => f.Password)
        .IsRequired()
        .HasColumnName("Password")
        .HasComment("Contraseña del usuario")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.HasMany(p => p.Rols)
               .WithMany(r => r.Users)
               .UsingEntity<UserRol>(

                   j => j
                   .HasOne(pt => pt.Rol)
                   .WithMany(t => t.UserRols)
                   .HasForeignKey(ut => ut.IdRolFK),

                   j => j
                   .HasOne(et => et.User)
                   .WithMany(et => et.UserRols)
                   .HasForeignKey(el => el.IdUserFK),

                   j =>
                   {
                       j.ToTable("UserRol");
                       j.HasKey(t => new { t.IdUserFK, t.IdRolFK });

                   });

        builder.HasMany(p => p.RefreshTokens)
        .WithOne(p => p.User)
        .HasForeignKey(p => p.IdUserFK);
    }
}