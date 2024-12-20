using Infrastructure.Base.ViewModel;

namespace API.Controllers.CadProduto.ViewModel;

public class UpsertRequestViewModel : BaseViewModel
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}
