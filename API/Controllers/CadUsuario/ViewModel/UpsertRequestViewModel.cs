using Infrastructure.Base.ViewModel;

namespace API.Controllers.CadUsuarios.ViewModel;

public class UpsertRequestViewModel : BaseViewModel
{
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public required string Senha { get; set; }
}
