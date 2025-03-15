using Infraestrutura.Base.Model;

namespace API.Models;

public class CadVisitante : BaseModel
{
    #region Construtores

    public CadVisitante() { }

    public CadVisitante(string nome, string email, string telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }

    #endregion

    #region Campos

    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public bool IsPresente { get; private set; } = false;

    #endregion

    #region Métodos públicos

    public void Update(string nome, string email, string telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }

    public void Presente()
    {
        IsPresente = true;
    }

    #endregion
}
