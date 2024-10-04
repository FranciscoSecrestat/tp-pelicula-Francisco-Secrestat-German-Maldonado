using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp_pelicula_Francisco_Secrestat.Migrations
{
    /// <inheritdoc />
    public partial class inicio2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEstreno = table.Column<int>(type: "int", nullable: false),
                    Portada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resumen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneroID = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peliculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_peliculas_actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "actor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_peliculas_generos_GeneroID",
                        column: x => x.GeneroID,
                        principalTable: "generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "peliculasActores",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    ActoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peliculasActores", x => new { x.PeliculaId, x.ActoresId });
                    table.ForeignKey(
                        name: "FK_peliculasActores_actor_ActoresId",
                        column: x => x.ActoresId,
                        principalTable: "actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_peliculasActores_peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_peliculas_ActorId",
                table: "peliculas",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_peliculas_GeneroID",
                table: "peliculas",
                column: "GeneroID");

            migrationBuilder.CreateIndex(
                name: "IX_peliculasActores_ActoresId",
                table: "peliculasActores",
                column: "ActoresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "peliculasActores");

            migrationBuilder.DropTable(
                name: "peliculas");

            migrationBuilder.DropTable(
                name: "actor");

            migrationBuilder.DropTable(
                name: "generos");
        }
    }
}
