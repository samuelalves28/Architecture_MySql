using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations;

public partial class AddTabelaUser : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "CadUsuarios",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Nome = table.Column<string>(maxLength: 100, nullable: false),
                Email = table.Column<string>(maxLength: 100, nullable: false),
                DataNascimento = table.Column<DateTime>(nullable: false),
                PasswordHash = table.Column<string>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CadUsuarios", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "CadUsuarios");
    }
}

