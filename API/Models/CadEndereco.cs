using Infraestrutura.Base.Model;

namespace API.Models;

public class CadEndereco : BaseModel
{
    #region Construtores

    public CadEndereco() { }

    public CadEndereco(string cep,
        string logradouro,
        string numero,
        string complemento,
        string bairro,
        string cidade,
        string estado,
        CadVisitante cadVisitante)
    {
        CEP = cep;
        Logradouro = logradouro;
        Numero = numero;
        Complemento = complemento;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        CadVisitante = cadVisitante;
        CadVisitanteId = cadVisitante.Id;
    }

    #endregion

    #region Campos

    public string CEP { get; private set; }
    public string Logradouro { get; private set; }
    public string Numero { get; private set; }
    public string Complemento { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }

    public int CadVisitanteId { get; private set; }
    public CadVisitante CadVisitante { get; private set; }

    #endregion

    #region Métodos públicos

    public void Update(string cep,
        string logradouro,
        string numero,
        string complemento,
        string bairro,
        string cidade,
        string estado)
    {
        CEP = cep;
        Logradouro = logradouro;
        Numero = numero;
        Complemento = complemento;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
    }

    #endregion
}
