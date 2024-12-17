using Infrastructure.Base.Model;

namespace API.Models;

public class CadProduto(string nome, string descricao, decimal preco) : BaseModel
{
    public string Nome { get; private set; } = nome;
    public string Descricao { get; private set; } = descricao;
    public decimal Preco { get; private set; } = preco;

    public void Update(string nome, string descricao, decimal preco)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
    }
}

