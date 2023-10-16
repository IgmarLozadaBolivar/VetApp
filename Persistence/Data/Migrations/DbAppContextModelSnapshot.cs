﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(DbAppContext))]
    partial class DbAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Cita", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("Fecha")
                        .HasComment("Fecha de la cita");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("time")
                        .HasColumnName("Hora")
                        .HasComment("Hora de la cita");

                    b.Property<string>("IdMascotaFK")
                        .HasColumnType("text");

                    b.Property<string>("IdVeterinarioFK")
                        .HasColumnType("text");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("Motivo")
                        .HasComment("Motivo de la cita");

                    b.HasKey("Id");

                    b.HasIndex("IdMascotaFK");

                    b.HasIndex("IdVeterinarioFK");

                    b.ToTable("Cita", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.DetalleMovimiento", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("Cantidad")
                        .HasComment("Cantidad del movimiento");

                    b.Property<string>("IdMedicamentoFK")
                        .HasColumnType("text");

                    b.Property<string>("IdMovMedFK")
                        .HasColumnType("text");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal")
                        .HasColumnName("Precio")
                        .HasComment("Precio del movimiento");

                    b.HasKey("Id");

                    b.HasIndex("IdMedicamentoFK");

                    b.HasIndex("IdMovMedFK");

                    b.ToTable("DetalleMovimiento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Especie", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre")
                        .HasComment("Nombre de la especie");

                    b.HasKey("Id");

                    b.ToTable("Especie", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Laboratorio", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Direccion")
                        .HasComment("Direccion del laboratorio");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre")
                        .HasComment("Nombre del laboratorio");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("Telefono")
                        .HasComment("Numero del telefono celular del laboratorio");

                    b.HasKey("Id");

                    b.ToTable("Laboratorio", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Mascota", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<string>("FechaNac")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Fecha Nacimiento")
                        .HasComment("Fecha de nacimiento de la mascota");

                    b.Property<string>("IdEspecieFK")
                        .HasColumnType("text");

                    b.Property<string>("IdPropietarioFK")
                        .HasColumnType("text");

                    b.Property<string>("IdRazaFK")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre")
                        .HasComment("Nombre de la mascota");

                    b.HasKey("Id");

                    b.HasIndex("IdEspecieFK");

                    b.HasIndex("IdPropietarioFK");

                    b.HasIndex("IdRazaFK");

                    b.ToTable("Mascota", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Medicamento", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<string>("IdLaboratorioFK")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre")
                        .HasComment("Nombre del medicamento");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal")
                        .HasColumnName("Precio")
                        .HasComment("Precio del medicamento");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("StockDisponible")
                        .HasComment("Cantidad disponible del medicamento");

                    b.HasKey("Id");

                    b.HasIndex("IdLaboratorioFK");

                    b.ToTable("Medicamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MovimientoMedicamento", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Fecha")
                        .HasComment("Fecha del movimiento");

                    b.Property<string>("IdMedicamentoFK")
                        .HasColumnType("text");

                    b.Property<string>("IdPropietarioFK")
                        .HasColumnType("text");

                    b.Property<string>("IdTipoMovimientoFK")
                        .HasColumnType("text");

                    b.Property<int>("Total")
                        .HasColumnType("int")
                        .HasColumnName("Total")
                        .HasComment("Total del movimiento");

                    b.HasKey("Id");

                    b.HasIndex("IdMedicamentoFK");

                    b.HasIndex("IdPropietarioFK");

                    b.HasIndex("IdTipoMovimientoFK");

                    b.ToTable("MovimientoMedicamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Propietario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("Email")
                        .HasComment("Correo electronico del propietario");

                    b.Property<string>("IdUserFK")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre")
                        .HasComment("Nombre del propietario");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("Telefono")
                        .HasComment("Telefono del propietario");

                    b.HasKey("Id");

                    b.HasIndex("IdUserFK");

                    b.ToTable("Propietario", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Proveedor", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Direccion")
                        .HasComment("Direccion del proveedor");

                    b.Property<string>("IdUserFK")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre")
                        .HasComment("Nombre del proveedor");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("Telefono")
                        .HasComment("Telefono del proveedor");

                    b.HasKey("Id");

                    b.HasIndex("IdUserFK");

                    b.ToTable("Proveedor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProveedorMedicamento", b =>
                {
                    b.Property<string>("IdProveedorFK")
                        .HasColumnType("text");

                    b.Property<string>("IdMedicamentoFK")
                        .HasColumnType("text");

                    b.HasKey("IdProveedorFK", "IdMedicamentoFK");

                    b.HasIndex("IdMedicamentoFK");

                    b.ToTable("ProveedorMedicamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Raza", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<string>("IdEspecieFK")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre")
                        .HasComment("Nombre de la raza");

                    b.HasKey("Id");

                    b.HasIndex("IdEspecieFK");

                    b.ToTable("Raza", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Created")
                        .HasComment("Creacion del token");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Expires")
                        .HasComment("Expiracion del token");

                    b.Property<string>("IdUserFK")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("Token")
                        .HasComment("Token del usuario");

                    b.HasKey("Id");

                    b.HasIndex("IdUserFK");

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre")
                        .HasComment("Nombre del rol");

                    b.HasKey("Id");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TipoMovimiento", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("Descripcion")
                        .HasComment("Descripcion del tipo de movimiento");

                    b.HasKey("Id");

                    b.ToTable("Tipo Movimiento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TratamientoMedico", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<string>("DetalleConsumo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("DetalleConsumo")
                        .HasComment("Detalles del consumo de la dosis");

                    b.Property<string>("Dosis")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Dosis")
                        .HasComment("Dosis del tratamiento medico");

                    b.Property<string>("IdCitaFK")
                        .HasColumnType("text");

                    b.Property<string>("IdMedicamentoFK")
                        .HasColumnType("text");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("Observacion")
                        .HasComment("Observaciones del tratamiento medico");

                    b.HasKey("Id");

                    b.HasIndex("IdCitaFK");

                    b.HasIndex("IdMedicamentoFK");

                    b.ToTable("TratamientoMedico", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Mail")
                        .HasComment("Correo del usuario");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Password")
                        .HasComment("Contraseña del usuario");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Username")
                        .HasComment("Nombre del usuario");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.Property<string>("IdUserFK")
                        .HasColumnType("text");

                    b.Property<string>("IdRolFK")
                        .HasColumnType("text");

                    b.HasKey("IdUserFK", "IdRolFK");

                    b.HasIndex("IdRolFK");

                    b.ToTable("UserRol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Veterinario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValueSql("substring(gen_random_uuid()::text, 1, 7)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("Email")
                        .HasComment("Correo electronico del veterinario");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Especialidad")
                        .HasComment("Especialidad del veterinario");

                    b.Property<string>("IdUserFK")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre")
                        .HasComment("Nombre del veterinario");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("Telefono")
                        .HasComment("Telefono del veterinario");

                    b.HasKey("Id");

                    b.HasIndex("IdUserFK");

                    b.ToTable("Veterinario", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Cita", b =>
                {
                    b.HasOne("Domain.Entities.Mascota", "Mascota")
                        .WithMany("Citas")
                        .HasForeignKey("IdMascotaFK");

                    b.HasOne("Domain.Entities.Veterinario", "Veterinario")
                        .WithMany("Citas")
                        .HasForeignKey("IdVeterinarioFK");

                    b.Navigation("Mascota");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("Domain.Entities.DetalleMovimiento", b =>
                {
                    b.HasOne("Domain.Entities.Medicamento", "Medicamento")
                        .WithMany("DetalleMovimientos")
                        .HasForeignKey("IdMedicamentoFK");

                    b.HasOne("Domain.Entities.MovimientoMedicamento", "MovimientoMedicamento")
                        .WithMany("DetalleMovimientos")
                        .HasForeignKey("IdMovMedFK");

                    b.Navigation("Medicamento");

                    b.Navigation("MovimientoMedicamento");
                });

            modelBuilder.Entity("Domain.Entities.Mascota", b =>
                {
                    b.HasOne("Domain.Entities.Especie", "Especie")
                        .WithMany("Mascotas")
                        .HasForeignKey("IdEspecieFK");

                    b.HasOne("Domain.Entities.Propietario", "Propietario")
                        .WithMany("Mascotas")
                        .HasForeignKey("IdPropietarioFK");

                    b.HasOne("Domain.Entities.Raza", "Raza")
                        .WithMany("Mascotas")
                        .HasForeignKey("IdRazaFK");

                    b.Navigation("Especie");

                    b.Navigation("Propietario");

                    b.Navigation("Raza");
                });

            modelBuilder.Entity("Domain.Entities.Medicamento", b =>
                {
                    b.HasOne("Domain.Entities.Laboratorio", "Laboratorio")
                        .WithMany("Medicamentos")
                        .HasForeignKey("IdLaboratorioFK");

                    b.Navigation("Laboratorio");
                });

            modelBuilder.Entity("Domain.Entities.MovimientoMedicamento", b =>
                {
                    b.HasOne("Domain.Entities.Medicamento", "Medicamento")
                        .WithMany("MovimientoMedicamentos")
                        .HasForeignKey("IdMedicamentoFK");

                    b.HasOne("Domain.Entities.Propietario", "Propietario")
                        .WithMany("MovimientoMedicamentos")
                        .HasForeignKey("IdPropietarioFK");

                    b.HasOne("Domain.Entities.TipoMovimiento", "TipoMovimiento")
                        .WithMany("MovimientoMedicamentos")
                        .HasForeignKey("IdTipoMovimientoFK");

                    b.Navigation("Medicamento");

                    b.Navigation("Propietario");

                    b.Navigation("TipoMovimiento");
                });

            modelBuilder.Entity("Domain.Entities.Propietario", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Propietarios")
                        .HasForeignKey("IdUserFK");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Proveedor", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Proveedores")
                        .HasForeignKey("IdUserFK");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.ProveedorMedicamento", b =>
                {
                    b.HasOne("Domain.Entities.Medicamento", "Medicamento")
                        .WithMany("ProveedorMedicamentos")
                        .HasForeignKey("IdMedicamentoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Proveedor", "Proveedor")
                        .WithMany("ProveedorMedicamentos")
                        .HasForeignKey("IdProveedorFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Domain.Entities.Raza", b =>
                {
                    b.HasOne("Domain.Entities.Especie", "Especie")
                        .WithMany("Razas")
                        .HasForeignKey("IdEspecieFK");

                    b.Navigation("Especie");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("IdUserFK");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.TratamientoMedico", b =>
                {
                    b.HasOne("Domain.Entities.Cita", "Cita")
                        .WithMany("TratamientoMedicos")
                        .HasForeignKey("IdCitaFK");

                    b.HasOne("Domain.Entities.Medicamento", "Medicamento")
                        .WithMany("TratamientoMedicos")
                        .HasForeignKey("IdMedicamentoFK");

                    b.Navigation("Cita");

                    b.Navigation("Medicamento");
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("UserRols")
                        .HasForeignKey("IdRolFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserRols")
                        .HasForeignKey("IdUserFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Veterinario", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Veterinarios")
                        .HasForeignKey("IdUserFK");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Cita", b =>
                {
                    b.Navigation("TratamientoMedicos");
                });

            modelBuilder.Entity("Domain.Entities.Especie", b =>
                {
                    b.Navigation("Mascotas");

                    b.Navigation("Razas");
                });

            modelBuilder.Entity("Domain.Entities.Laboratorio", b =>
                {
                    b.Navigation("Medicamentos");
                });

            modelBuilder.Entity("Domain.Entities.Mascota", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("Domain.Entities.Medicamento", b =>
                {
                    b.Navigation("DetalleMovimientos");

                    b.Navigation("MovimientoMedicamentos");

                    b.Navigation("ProveedorMedicamentos");

                    b.Navigation("TratamientoMedicos");
                });

            modelBuilder.Entity("Domain.Entities.MovimientoMedicamento", b =>
                {
                    b.Navigation("DetalleMovimientos");
                });

            modelBuilder.Entity("Domain.Entities.Propietario", b =>
                {
                    b.Navigation("Mascotas");

                    b.Navigation("MovimientoMedicamentos");
                });

            modelBuilder.Entity("Domain.Entities.Proveedor", b =>
                {
                    b.Navigation("ProveedorMedicamentos");
                });

            modelBuilder.Entity("Domain.Entities.Raza", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Navigation("UserRols");
                });

            modelBuilder.Entity("Domain.Entities.TipoMovimiento", b =>
                {
                    b.Navigation("MovimientoMedicamentos");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Propietarios");

                    b.Navigation("Proveedores");

                    b.Navigation("RefreshTokens");

                    b.Navigation("UserRols");

                    b.Navigation("Veterinarios");
                });

            modelBuilder.Entity("Domain.Entities.Veterinario", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
