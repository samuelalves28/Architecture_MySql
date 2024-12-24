using Infrastructure.Base.Model;

namespace API.Models;
public class CadUsuario(string nome, string email, string passwordHash) : BaseModel
{
    #region Campos

    public string Nome { get; private set; } = nome;
    public string Email { get; private set; } = email;
    public DateTime DataNascimento { get; private set; }
    public string PasswordHash { get; private set; } = passwordHash;

    #endregion

    #region Métodos públicos

    public void Update(string nome, string email, DateTime dataNascimento, string passwordHash)
    {
        Nome = nome;
        Email = email;
        DataNascimento = dataNascimento;
        PasswordHash = passwordHash;
    }

    public int GetIdade()
    {
        var today = DateTime.Today;
        var idade = today.Year - DataNascimento.Year;

        if (DataNascimento.Date > today.AddYears(-idade)) idade--;

        return idade;
    }

    #endregion
}
