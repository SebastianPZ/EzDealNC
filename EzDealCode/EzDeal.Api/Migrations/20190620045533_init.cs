using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EzDeal.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anuncios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    anunciante_id = table.Column<int>(nullable: false),
                    titulo = table.Column<string>(maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    costo_servicio = table.Column<int>(nullable: false),
                    servicio = table.Column<string>(nullable: true),
                    esta_habilitado = table.Column<int>(nullable: false),
                    valoracion = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
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
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Reseñas",
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
                    table.PrimaryKey("PK_Reseñas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reseñas_Anuncios_anuncioid",
                        column: x => x.anuncioid,
                        principalTable: "Anuncios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reseñas_Usuarios_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
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
                    table.PrimaryKey("PK_Solicitudes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Anuncios_anuncioid",
                        column: x => x.anuncioid,
                        principalTable: "Anuncios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Usuarios_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_anuncioid",
                table: "Reseñas",
                column: "anuncioid");

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_clienteid",
                table: "Reseñas",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_anuncioid",
                table: "Solicitudes",
                column: "anuncioid");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_clienteid",
                table: "Solicitudes",
                column: "clienteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reseñas");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Anuncios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
