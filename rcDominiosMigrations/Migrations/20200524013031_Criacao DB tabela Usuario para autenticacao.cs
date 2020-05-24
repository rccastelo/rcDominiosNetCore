using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rcDominiosMigrations.Migrations
{
    public partial class CriacaoDBtabelaUsuarioparaautenticacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apelido = table.Column<string>(maxLength: 40, nullable: true),
                    Senha = table.Column<string>(maxLength: 40, nullable: true),
                    NomeApresentacao = table.Column<string>(maxLength: 40, nullable: true),
                    NomeCompleto = table.Column<string>(maxLength: 200, nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Criacao = table.Column<DateTime>(nullable: false),
                    Alteracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
