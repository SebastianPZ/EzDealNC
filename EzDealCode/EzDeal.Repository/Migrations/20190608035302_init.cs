using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EzDeal.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicioDb",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioDb", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDb",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    contraseña = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    url_contacto = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    rol = table.Column<string>(nullable: false),
                    distrito = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDb", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AnuncioDb",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    anunciante_id = table.Column<int>(nullable: false),
                    titulo = table.Column<string>(nullable: true),
                    descripcion = table.Column<string>(nullable: true),
                    costo_servicio = table.Column<int>(nullable: false),
                    servicioid = table.Column<int>(nullable: true),
                    esta_habilitado = table.Column<int>(nullable: false),
                    valoracion = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnuncioDb", x => x.id);
                    table.ForeignKey(
                        name: "FK_AnuncioDb_ServicioDb_servicioid",
                        column: x => x.servicioid,
                        principalTable: "ServicioDb",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReseñaDb",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    contenido = table.Column<string>(nullable: true),
                    valoracion = table.Column<float>(nullable: false),
                    anuncioid = table.Column<int>(nullable: true),
                    clienteid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReseñaDb", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReseñaDb_AnuncioDb_anuncioid",
                        column: x => x.anuncioid,
                        principalTable: "AnuncioDb",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReseñaDb_UsuarioDb_clienteid",
                        column: x => x.clienteid,
                        principalTable: "UsuarioDb",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudDb",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    anuncioid = table.Column<int>(nullable: true),
                    clienteid = table.Column<int>(nullable: true),
                    mensaje = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: true),
                    aprobacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudDb", x => x.id);
                    table.ForeignKey(
                        name: "FK_SolicitudDb_AnuncioDb_anuncioid",
                        column: x => x.anuncioid,
                        principalTable: "AnuncioDb",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitudDb_UsuarioDb_clienteid",
                        column: x => x.clienteid,
                        principalTable: "UsuarioDb",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnuncioDb_servicioid",
                table: "AnuncioDb",
                column: "servicioid");

            migrationBuilder.CreateIndex(
                name: "IX_ReseñaDb_anuncioid",
                table: "ReseñaDb",
                column: "anuncioid");

            migrationBuilder.CreateIndex(
                name: "IX_ReseñaDb_clienteid",
                table: "ReseñaDb",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudDb_anuncioid",
                table: "SolicitudDb",
                column: "anuncioid");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudDb_clienteid",
                table: "SolicitudDb",
                column: "clienteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReseñaDb");

            migrationBuilder.DropTable(
                name: "SolicitudDb");

            migrationBuilder.DropTable(
                name: "AnuncioDb");

            migrationBuilder.DropTable(
                name: "UsuarioDb");

            migrationBuilder.DropTable(
                name: "ServicioDb");
        }
    }
}
