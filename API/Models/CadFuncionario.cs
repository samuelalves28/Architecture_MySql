using Infrastructure.Base.Model;

namespace API.Models;

public class CadFuncionario : BaseModel
{
    public bool IsAtivo { get; private set; }
    public string Nome { get; private set; }
    public string CPF { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public string SenhaSalt { get; private set; }
    public TimeSpan HorarioInicio { get; private set; }
    public TimeSpan HorarioFinal { get; private set; }
    public decimal CargaHorariaDiaria { get; private set; }
    public decimal CargaHorariaSemanal { get; private set; }
    public string DiasDaSemana { get; private set; }
}
