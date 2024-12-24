using API.Controllers.CadUsuarios.ViewModel;
using API.Implementations.Interfaces;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc;
using static Infrastructure.Base.Controller.AuthBaseController;

namespace API.Controllers.CadUsuario;

[Route("api/adm/cad-usuarios")]
public class CadUsuarioController(ILogger<CadUsuarioController> logger, ICadUsuarioRepository cadUsuariosRepository) : AuthBSController
{
    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        => Ok(await cadUsuariosRepository.GetAsync(cancellationToken));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuarioAsync(Guid id, CancellationToken cancellationToken)
        => Ok(await cadUsuariosRepository.GetAsync(id, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> CreateAsync(UpsertRequestViewModel requestViewModel, CancellationToken cancellationToken)
    {
        try
        {
            var passwordHash = HashPassword.Create(requestViewModel.Senha);
            var model = new Models.CadUsuario(requestViewModel.Nome, requestViewModel.Email, passwordHash);

            await cadUsuariosRepository.CreateAsync(model, cancellationToken);
            return Ok("Cadastro de usuario feito com sucesso");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao adicionar o usuário");
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpsertRequestViewModel requestViewModel, CancellationToken cancellationToken)
    {
        try
        {
            var passwordHash = HashPassword.Create(requestViewModel.Senha);
            var model = await cadUsuariosRepository.GetAsync(id: requestViewModel.Id!.Value, cancellationToken);
            model.Update(requestViewModel.Nome, requestViewModel.Email, requestViewModel.DataNascimento, passwordHash);

            await cadUsuariosRepository.UpdateAsync(model, cancellationToken);
            return Ok("Cadastro de usuario atualizado com sucesso");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao atualizar o usuário");
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await cadUsuariosRepository.DeleteAsync(id, cancellationToken);
            return Ok("Cadastro de usuario delerado com sucesso");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao deletar o usuário");
            return BadRequest();
        }
    }
}
