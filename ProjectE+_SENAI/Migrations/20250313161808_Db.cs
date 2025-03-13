using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectE__SENAI.Migrations
{
    /// <inheritdoc />
    public partial class Db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    IdInstituição = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Local = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Vestimenta = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CNPJ = table.Column<string>(type: "CHAR(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.IdInstituição);
                });

            migrationBuilder.CreateTable(
                name: "TiposEventos",
                columns: table => new
                {
                    IdTiposEventos = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTiposEventos = table.Column<string>(type: "VARCHAR(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEventos", x => x.IdTiposEventos);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuarios",
                columns: table => new
                {
                    IdTiposUsuarios = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTiposUsuarios = table.Column<string>(type: "Char(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuarios", x => x.IdTiposUsuarios);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(30)", maxLength: 60, nullable: false),
                    IdTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TiposUsuarios = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_TiposUsuarios_TiposUsuarios",
                        column: x => x.TiposUsuarios,
                        principalTable: "TiposUsuarios",
                        principalColumn: "IdTiposUsuarios");
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    DataHora = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdTiposEventos = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPresenca = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_Evento_Instituicao_IdInstituicao",
                        column: x => x.IdInstituicao,
                        principalTable: "Instituicao",
                        principalColumn: "IdInstituição");
                    table.ForeignKey(
                        name: "FK_Evento_TiposEventos_IdTiposEventos",
                        column: x => x.IdTiposEventos,
                        principalTable: "TiposEventos",
                        principalColumn: "IdTiposEventos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    IdFeedback = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comentario = table.Column<string>(type: "VARCHAR(120)", nullable: false),
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventoIdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LocalIdInstituição = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.IdFeedback);
                    table.ForeignKey(
                        name: "FK_Feedback_Evento_EventoIdEvento",
                        column: x => x.EventoIdEvento,
                        principalTable: "Evento",
                        principalColumn: "IdEvento");
                    table.ForeignKey(
                        name: "FK_Feedback_Instituicao_LocalIdInstituição",
                        column: x => x.LocalIdInstituição,
                        principalTable: "Instituicao",
                        principalColumn: "IdInstituição");
                    table.ForeignKey(
                        name: "FK_Feedback_Usuario_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Presença",
                columns: table => new
                {
                    IdPresenca = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    comentário = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exibe = table.Column<string>(type: "VARCHAR(120)", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presença", x => x.IdPresenca);
                    table.ForeignKey(
                        name: "FK_Presença_Evento_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Evento",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Presença_Instituicao_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "Instituicao",
                        principalColumn: "IdInstituição");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evento_IdInstituicao",
                table: "Evento",
                column: "IdInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_IdPresenca",
                table: "Evento",
                column: "IdPresenca");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_IdTiposEventos",
                table: "Evento",
                column: "IdTiposEventos");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_EventoIdEvento",
                table: "Feedback",
                column: "EventoIdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_LocalIdInstituição",
                table: "Feedback",
                column: "LocalIdInstituição");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UsuarioIdUsuario",
                table: "Feedback",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicao_CNPJ",
                table: "Instituicao",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presença_IdEvento",
                table: "Presença",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Presença_IdUsuario",
                table: "Presença",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TiposUsuarios",
                table: "Usuario",
                column: "TiposUsuarios");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Presença_IdPresenca",
                table: "Evento",
                column: "IdPresenca",
                principalTable: "Presença",
                principalColumn: "IdPresenca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Instituicao_IdInstituicao",
                table: "Evento");

            migrationBuilder.DropForeignKey(
                name: "FK_Presença_Instituicao_IdEvento",
                table: "Presença");

            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Presença_IdPresenca",
                table: "Evento");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TiposUsuarios");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "Presença");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "TiposEventos");
        }
    }
}
