using Infrastructure.Base.Model;

namespace API.Models;

public class CadProduto(string nome, string descricao, decimal preco, int quantidade) : BaseModel
{
    public string Nome { get; private set; } = nome;
    public string Descricao { get; private set; } = descricao;
    public decimal Preco { get; private set; } = preco;
    public int Quantidade { get; private set; } = quantidade;

    public void Update(string nome, string descricao, decimal preco)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
    }

    public void UpdateQuantidade(int quantidade)
    {
        Quantidade = quantidade;
    }
}

