using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class adicionandovisitante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovRegistroPonto_CadUsuario_CadUsuarioId",
                table: "MovRegistroPonto");

            migrationBuilder.DropIndex(
                name: "IX_MovRegistroPonto_CadUsuarioId",
                table: "MovRegistroPonto");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MovRegistroPonto",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "CadUsuarioId1",
                table: "MovRegistroPonto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CadUsuario",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CadProduto",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CadFuncionario",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "CadVisitante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Telefone = table.Column<string>(type: "longtext", nullable: false),
                    IsPresente = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadVisitante", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CadEndereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CEP = table.Column<string>(type: "longtext", nullable: false),
                    Logradouro = table.Column<string>(type: "longtext", nullable: false),
                    Numero = table.Column<string>(type: "longtext", nullable: false),
                    Complemento = table.Column<string>(type: "longtext", nullable: false),
                    Bairro = table.Column<string>(type: "longtext", nullable: false),
                    Cidade = table.Column<string>(type: "longtext", nullable: false),
                    Estado = table.Column<string>(type: "longtext", nullable: false),
                    CadVisitanteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadEndereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CadEndereco_CadVisitante_CadVisitanteId",
                        column: x => x.CadVisitanteId,
                        principalTable: "CadVisitante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MovRegistroPonto_CadUsuarioId1",
                table: "MovRegistroPonto",
                column: "CadUsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_CadEndereco_CadVisitanteId",
                table: "CadEndereco",
                column: "CadVisitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovRegistroPonto_CadUsuario_CadUsuarioId1",
                table: "MovRegistroPonto",
                column: "CadUsuarioId1",
                principalTable: "CadUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovRegistroPonto_CadUsuario_CadUsuarioId1",
                table: "MovRegistroPonto");

            migrationBuilder.DropTable(
                name: "CadEndereco");

            migrationBuilder.DropTable(
                name: "CadVisitante");

            migrationBuilder.DropIndex(
                name: "IX_MovRegistroPonto_CadUsuarioId1",
                table: "MovRegistroPonto");

            migrationBuilder.DropColumn(
                name: "CadUsuarioId1",
                table: "MovRegistroPonto");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "MovRegistroPonto",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CadUsuario",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CadProduto",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CadFuncionario",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_MovRegistroPonto_CadUsuarioId",
                table: "MovRegistroPonto",
                column: "CadUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovRegistroPonto_CadUsuario_CadUsuarioId",
                table: "MovRegistroPonto",
                column: "CadUsuarioId",
                principalTable: "CadUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
