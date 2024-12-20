using API.Controllers.CadProduto.ViewModel;
using API.Implementations.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace API.Controllers.CadProduto;

[Route("api/adm/cad-produto")]
public class HomeController(ILogger<HomeController> logger, ICadProdutoRepository cadProdutoRepository) : ControllerBase
{
    [HttpGet("buscar")]
    public async Task<IActionResult> GetUsuariosAsync(CancellationToken cancellationToken)
        => Ok(await cadProdutoRepository.GetAsync(cancellationToken));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuarioAsync(Guid id, CancellationToken cancellationToken)
        => Ok(await cadProdutoRepository.GetAsync(id, cancellationToken));

    //[HttpPost]
    //public async Task<IActionResult> CriarUsuariosAsync([FromBody] UpsertRequestViewModel requestViewModel)
    //{
    //    try
    //    {
    //        var entity = new Models.CadUsuario(requestViewModel.Nome,
    //            requestViewModel.Email,
    //            HashPassword.Create(requestViewModel.Senha));

    //        await cadProdutoRepository.CreateAsync(entity);

    //        return Ok(new { message = "Cadastro feito com sucesso!" });
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest($"Erro ao cadastrar o usuario.{ex}");
    //        throw;
    //    }
    //}

    [HttpPut]
    public async Task<IActionResult> AtualizarUsuarioAsync([FromBody] UpsertRequestViewModel requestViewModel, CancellationToken cancellationToken)
    {
        try
        {
            var model = await cadProdutoRepository.GetAsync(id: requestViewModel.Id!.Value, cancellationToken);
            model.Update(requestViewModel.Nome, requestViewModel.Descricao, requestViewModel.Preco);

            await cadProdutoRepository.UpdateAsync(model, cancellationToken);

            return Ok(new { message = "Cadastro editado com sucesso!" });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao editar o usuario.{ex}");
            throw;
        }
    }

    //[HttpDelete, Route("{id}")]
    //public async Task<IActionResult> DeleteUsuarioAsync(Guid id)
    //{
    //    try
    //    {
    //        await cadProdutoRepository.DeleteAsync(id: id);
    //        return Ok(new { message = "Cadastro removido com sucesso!" });
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest($"Erro ao remover o usuario. {ex.Message}");
    //    }
    //}
}

