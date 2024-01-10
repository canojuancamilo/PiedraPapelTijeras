using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendPiendraPapelTijeras.Migrations
{
    /// <inheritdoc />
    public partial class migraciondemodelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    IdPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ganador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.IdPartida);
                });

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    IdJugador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPartida = table.Column<int>(type: "int", nullable: false),
                    PartidaIdPartida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.IdJugador);
                    table.ForeignKey(
                        name: "FK_Jugadores_Partidas_PartidaIdPartida",
                        column: x => x.PartidaIdPartida,
                        principalTable: "Partidas",
                        principalColumn: "IdPartida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    IdTurno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPartida = table.Column<int>(type: "int", nullable: false),
                    PartidaIdPartida = table.Column<int>(type: "int", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdJugadorGanador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.IdTurno);
                    table.ForeignKey(
                        name: "FK_Turnos_Jugadores_IdJugadorGanador",
                        column: x => x.IdJugadorGanador,
                        principalTable: "Jugadores",
                        principalColumn: "IdJugador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turnos_Partidas_PartidaIdPartida",
                        column: x => x.PartidaIdPartida,
                        principalTable: "Partidas",
                        principalColumn: "IdPartida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_PartidaIdPartida",
                table: "Jugadores",
                column: "PartidaIdPartida");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdJugadorGanador",
                table: "Turnos",
                column: "IdJugadorGanador");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_PartidaIdPartida",
                table: "Turnos",
                column: "PartidaIdPartida");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Partidas");
        }
    }
}
