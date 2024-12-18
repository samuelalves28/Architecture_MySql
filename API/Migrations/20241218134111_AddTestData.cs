using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO CadProduto (Id, Nome, Descricao, Preco, Quantidade) VALUES (UUID(), 'Arroz Integral', 'Arroz orgânico integral de 1kg', 12.99, 100)");
            migrationBuilder.Sql("INSERT INTO CadProduto (Id, Nome, Descricao, Preco, Quantidade) VALUES (UUID(), 'Feijão Preto', 'Feijão preto tipo 1 de 1kg', 8.49, 150)");
            migrationBuilder.Sql("INSERT INTO CadProduto (Id, Nome, Descricao, Preco, Quantidade) VALUES (UUID(), 'Açúcar Refinado', 'Açúcar refinado branco de 1kg', 4.99, 200)");
            migrationBuilder.Sql("INSERT INTO CadProduto (Id, Nome, Descricao, Preco, Quantidade) VALUES (UUID(), 'Óleo de Soja', 'Óleo de soja de 900ml', 6.79, 50)");
            migrationBuilder.Sql("INSERT INTO CadProduto (Id, Nome, Descricao, Preco, Quantidade) VALUES (UUID(), 'Macarrão Instantâneo', 'Macarrão instantâneo sabor galinha caipira de 85g', 2.49, 300)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM CadProduto WHERE Nome IN ('Arroz Integral', 'Feijão Preto', 'Açúcar Refinado', 'Óleo de Soja', 'Macarrão Instantâneo')");
        }
    }
}
