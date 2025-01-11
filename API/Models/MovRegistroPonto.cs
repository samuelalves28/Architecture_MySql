using Infrastructure.Base.Model;

namespace API.Models;

public class MovRegistroPonto : BaseModel
{
    public CadUsuario CadUsuario { get; private set; }
    public Guid CadUsuarioId { get; private set; }
    public DateTime DataRegistro { get; private set; }
    public TimeSpan HorarioEntrada { get; private set; }
    public TimeSpan HorarioSaida { get; private set; }
    public TimeSpan HorasTrabalhadas { get; private set; }
    public string? Justificativa { get; private set; }
}
