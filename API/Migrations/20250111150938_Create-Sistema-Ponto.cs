using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class CreateSistemaPonto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    IsAtivo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    CPF = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Senha = table.Column<string>(type: "longtext", nullable: false),
                    SenhaSalt = table.Column<string>(type: "longtext", nullable: false),
                    HorarioInicio = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    HorarioFinal = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    CargaHorariaDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CargaHorariaSemanal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiasDaSemana = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadFuncionario", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CadProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadProduto", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CadUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadUsuario", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovRegistroPonto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CadUsuarioId = table.Column<Guid>(type: "char(36)", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HorarioEntrada = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    HorarioSaida = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    HorasTrabalhadas = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Justificativa = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovRegistroPonto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovRegistroPonto_CadUsuario_CadUsuarioId",
                        column: x => x.CadUsuarioId,
                        principalTable: "CadUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MovRegistroPonto_CadUsuarioId",
                table: "MovRegistroPonto",
                column: "CadUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadFuncionario");

            migrationBuilder.DropTable(
                name: "CadProduto");

            migrationBuilder.DropTable(
                name: "MovRegistroPonto");

            migrationBuilder.DropTable(
                name: "CadUsuario");
        }
    }
}
