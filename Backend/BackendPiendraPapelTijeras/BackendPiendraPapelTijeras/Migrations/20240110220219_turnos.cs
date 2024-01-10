using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendPiendraPapelTijeras.Migrations
{
    /// <inheritdoc />
    public partial class turnos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resultado",
                table: "Turnos");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Turnos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Turnos");

            migrationBuilder.AddColumn<string>(
                name: "Resultado",
                table: "Turnos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
