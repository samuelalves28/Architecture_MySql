using API.Implementations.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CadProduto;

[Route("api/adm/cad-cadastro")]
public class HomeController(ILogger<HomeController> logger, ICadProdutoRepository cadProdutoRepository) : ControllerBase
{
    [HttpGet("buscar")]
    public async Task<IActionResult> GetUsuariosAsync()
    {
        var users = await cadProdutoRepository.GetAllAsync();
        return Ok(users);
    }


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

    //[HttpPut]
    //public async Task<IActionResult> AtualizarUsuarioAsync([FromBody] UpsertRequestViewModel requestViewModel)
    //{
    //    try
    //    {
    //        var entity = await cadProdutoRepository.GetAsync(id: requestViewModel.Id.Value);
    //        entity.Update(requestViewModel.Nome, requestViewModel.Email, HashPassword.Create(requestViewModel.Senha));

    //        await cadProdutoRepository.UpdateAsync(requestViewModel.Id.Value, entity);

    //        return Ok(new { message = "Cadastro editado com sucesso!" });
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest($"Erro ao editar o usuario.{ex}");
    //        throw;
    //    }
    //}

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

