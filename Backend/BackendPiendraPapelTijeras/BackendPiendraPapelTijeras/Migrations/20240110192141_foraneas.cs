using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendPiendraPapelTijeras.Migrations
{
    /// <inheritdoc />
    public partial class Foraneas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Partidas_PartidaIdPartida",
                table: "Jugadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Partidas_PartidaIdPartida",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_PartidaIdPartida",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Jugadores_PartidaIdPartida",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "PartidaIdPartida",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "PartidaIdPartida",
                table: "Jugadores");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdPartida",
                table: "Turnos",
                column: "IdPartida");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_IdPartida",
                table: "Jugadores",
                column: "IdPartida");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Partidas_IdPartida",
                table: "Jugadores",
                column: "IdPartida",
                principalTable: "Partidas",
                principalColumn: "IdPartida",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Partidas_IdPartida",
                table: "Turnos",
                column: "IdPartida",
                principalTable: "Partidas",
                principalColumn: "IdPartida",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Partidas_IdPartida",
                table: "Jugadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Partidas_IdPartida",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_IdPartida",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Jugadores_IdPartida",
                table: "Jugadores");

            migrationBuilder.AddColumn<int>(
                name: "PartidaIdPartida",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartidaIdPartida",
                table: "Jugadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PartidaIdPartida",
                table: "Turnos",
                column: "PartidaIdPartida");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_PartidaIdPartida",
                table: "Jugadores",
                column: "PartidaIdPartida");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Partidas_PartidaIdPartida",
                table: "Jugadores",
                column: "PartidaIdPartida",
                principalTable: "Partidas",
                principalColumn: "IdPartida",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Partidas_PartidaIdPartida",
                table: "Turnos",
                column: "PartidaIdPartida",
                principalTable: "Partidas",
                principalColumn: "IdPartida",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
