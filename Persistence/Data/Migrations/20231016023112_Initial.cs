using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Nombre de la especie")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorio",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Nombre del laboratorio"),
                    Direccion = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Direccion del laboratorio"),
                    Telefono = table.Column<string>(type: "varchar", maxLength: 30, nullable: false, comment: "Numero del telefono celular del laboratorio")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Nombre del rol")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo Movimiento",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    Descripcion = table.Column<string>(type: "varchar", maxLength: 150, nullable: false, comment: "Descripcion del tipo de movimiento")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo Movimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    Mail = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Correo del usuario"),
                    Username = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Nombre del usuario"),
                    Password = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Contraseña del usuario")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Raza",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    IdEspecieFK = table.Column<string>(type: "text", nullable: true),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Nombre de la raza")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raza_Especie_IdEspecieFK",
                        column: x => x.IdEspecieFK,
                        principalTable: "Especie",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Nombre del medicamento"),
                    StockDisponible = table.Column<int>(type: "int", nullable: false, comment: "Cantidad disponible del medicamento"),
                    Precio = table.Column<decimal>(type: "decimal", nullable: false, comment: "Precio del medicamento"),
                    IdLaboratorioFK = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamento_Laboratorio_IdLaboratorioFK",
                        column: x => x.IdLaboratorioFK,
                        principalTable: "Laboratorio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Nombre del propietario"),
                    Email = table.Column<string>(type: "varchar", maxLength: 150, nullable: false, comment: "Correo electronico del propietario"),
                    Telefono = table.Column<string>(type: "varchar", maxLength: 30, nullable: false, comment: "Telefono del propietario"),
                    IdUserFK = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propietario_User_IdUserFK",
                        column: x => x.IdUserFK,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Nombre del proveedor"),
                    Direccion = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Direccion del proveedor"),
                    Telefono = table.Column<string>(type: "varchar", maxLength: 30, nullable: false, comment: "Telefono del proveedor"),
                    IdUserFK = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedor_User_IdUserFK",
                        column: x => x.IdUserFK,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    IdUserFK = table.Column<string>(type: "text", nullable: true),
                    Token = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Token del usuario"),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Expiracion del token"),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Creacion del token"),
                    Revoked = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Revocacion del token")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_IdUserFK",
                        column: x => x.IdUserFK,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRol",
                columns: table => new
                {
                    IdUserFK = table.Column<string>(type: "text", nullable: false),
                    IdRolFK = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRol", x => new { x.IdUserFK, x.IdRolFK });
                    table.ForeignKey(
                        name: "FK_UserRol_Rol_IdRolFK",
                        column: x => x.IdRolFK,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRol_User_IdUserFK",
                        column: x => x.IdUserFK,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veterinario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Nombre del veterinario"),
                    Email = table.Column<string>(type: "varchar", maxLength: 150, nullable: false, comment: "Correo electronico del veterinario"),
                    Telefono = table.Column<string>(type: "varchar", maxLength: 30, nullable: false, comment: "Telefono del veterinario"),
                    Especialidad = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Especialidad del veterinario"),
                    IdUserFK = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veterinario_User_IdUserFK",
                        column: x => x.IdUserFK,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    IdPropietarioFK = table.Column<string>(type: "text", nullable: true),
                    IdEspecieFK = table.Column<string>(type: "text", nullable: true),
                    IdRazaFK = table.Column<string>(type: "text", nullable: true),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Nombre de la mascota"),
                    FechaNacimiento = table.Column<string>(name: "Fecha Nacimiento", type: "text", nullable: false, comment: "Fecha de nacimiento de la mascota")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascota_Especie_IdEspecieFK",
                        column: x => x.IdEspecieFK,
                        principalTable: "Especie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mascota_Propietario_IdPropietarioFK",
                        column: x => x.IdPropietarioFK,
                        principalTable: "Propietario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mascota_Raza_IdRazaFK",
                        column: x => x.IdRazaFK,
                        principalTable: "Raza",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovimientoMedicamento",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha del movimiento"),
                    IdMedicamentoFK = table.Column<string>(type: "text", nullable: true),
                    IdPropietarioFK = table.Column<string>(type: "text", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: false, comment: "Total del movimiento"),
                    IdTipoMovimientoFK = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoMedicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientoMedicamento_Medicamento_IdMedicamentoFK",
                        column: x => x.IdMedicamentoFK,
                        principalTable: "Medicamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovimientoMedicamento_Propietario_IdPropietarioFK",
                        column: x => x.IdPropietarioFK,
                        principalTable: "Propietario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovimientoMedicamento_Tipo Movimiento_IdTipoMovimientoFK",
                        column: x => x.IdTipoMovimientoFK,
                        principalTable: "Tipo Movimiento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProveedorMedicamento",
                columns: table => new
                {
                    IdMedicamentoFK = table.Column<string>(type: "text", nullable: false),
                    IdProveedorFK = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorMedicamento", x => new { x.IdProveedorFK, x.IdMedicamentoFK });
                    table.ForeignKey(
                        name: "FK_ProveedorMedicamento_Medicamento_IdMedicamentoFK",
                        column: x => x.IdMedicamentoFK,
                        principalTable: "Medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProveedorMedicamento_Proveedor_IdProveedorFK",
                        column: x => x.IdProveedorFK,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    IdMascotaFK = table.Column<string>(type: "text", nullable: true),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false, comment: "Fecha de la cita"),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false, comment: "Hora de la cita"),
                    Motivo = table.Column<string>(type: "varchar", maxLength: 150, nullable: false, comment: "Motivo de la cita"),
                    IdVeterinarioFK = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cita_Mascota_IdMascotaFK",
                        column: x => x.IdMascotaFK,
                        principalTable: "Mascota",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cita_Veterinario_IdVeterinarioFK",
                        column: x => x.IdVeterinarioFK,
                        principalTable: "Veterinario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetalleMovimiento",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    IdMedicamentoFK = table.Column<string>(type: "text", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false, comment: "Cantidad del movimiento"),
                    IdMovMedFK = table.Column<string>(type: "text", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal", nullable: false, comment: "Precio del movimiento")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleMovimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_Medicamento_IdMedicamentoFK",
                        column: x => x.IdMedicamentoFK,
                        principalTable: "Medicamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_MovimientoMedicamento_IdMovMedFK",
                        column: x => x.IdMovMedFK,
                        principalTable: "MovimientoMedicamento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TratamientoMedico",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "substring(gen_random_uuid()::text, 1, 7)"),
                    IdCitaFK = table.Column<string>(type: "text", nullable: true),
                    IdMedicamentoFK = table.Column<string>(type: "text", nullable: true),
                    Dosis = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Dosis del tratamiento medico"),
                    DetalleConsumo = table.Column<string>(type: "varchar", maxLength: 150, nullable: false, comment: "Detalles del consumo de la dosis"),
                    Observacion = table.Column<string>(type: "varchar", maxLength: 150, nullable: false, comment: "Observaciones del tratamiento medico")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamientoMedico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamientoMedico_Cita_IdCitaFK",
                        column: x => x.IdCitaFK,
                        principalTable: "Cita",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TratamientoMedico_Medicamento_IdMedicamentoFK",
                        column: x => x.IdMedicamentoFK,
                        principalTable: "Medicamento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdMascotaFK",
                table: "Cita",
                column: "IdMascotaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdVeterinarioFK",
                table: "Cita",
                column: "IdVeterinarioFK");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_IdMedicamentoFK",
                table: "DetalleMovimiento",
                column: "IdMedicamentoFK");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_IdMovMedFK",
                table: "DetalleMovimiento",
                column: "IdMovMedFK");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdEspecieFK",
                table: "Mascota",
                column: "IdEspecieFK");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdPropietarioFK",
                table: "Mascota",
                column: "IdPropietarioFK");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdRazaFK",
                table: "Mascota",
                column: "IdRazaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_IdLaboratorioFK",
                table: "Medicamento",
                column: "IdLaboratorioFK");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoMedicamento_IdMedicamentoFK",
                table: "MovimientoMedicamento",
                column: "IdMedicamentoFK");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoMedicamento_IdPropietarioFK",
                table: "MovimientoMedicamento",
                column: "IdPropietarioFK");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoMedicamento_IdTipoMovimientoFK",
                table: "MovimientoMedicamento",
                column: "IdTipoMovimientoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Propietario_IdUserFK",
                table: "Propietario",
                column: "IdUserFK");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_IdUserFK",
                table: "Proveedor",
                column: "IdUserFK");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorMedicamento_IdMedicamentoFK",
                table: "ProveedorMedicamento",
                column: "IdMedicamentoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Raza_IdEspecieFK",
                table: "Raza",
                column: "IdEspecieFK");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_IdUserFK",
                table: "RefreshToken",
                column: "IdUserFK");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientoMedico_IdCitaFK",
                table: "TratamientoMedico",
                column: "IdCitaFK");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientoMedico_IdMedicamentoFK",
                table: "TratamientoMedico",
                column: "IdMedicamentoFK");

            migrationBuilder.CreateIndex(
                name: "IX_UserRol_IdRolFK",
                table: "UserRol",
                column: "IdRolFK");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinario_IdUserFK",
                table: "Veterinario",
                column: "IdUserFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleMovimiento");

            migrationBuilder.DropTable(
                name: "ProveedorMedicamento");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "TratamientoMedico");

            migrationBuilder.DropTable(
                name: "UserRol");

            migrationBuilder.DropTable(
                name: "MovimientoMedicamento");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "Tipo Movimiento");

            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "Veterinario");

            migrationBuilder.DropTable(
                name: "Laboratorio");

            migrationBuilder.DropTable(
                name: "Propietario");

            migrationBuilder.DropTable(
                name: "Raza");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Especie");
        }
    }
}
