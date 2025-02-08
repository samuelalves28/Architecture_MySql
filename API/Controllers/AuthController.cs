using API.Implementations.Interfaces;
using API.Services.JwtToken;
using API.ViewModels;
using Infraestrutura.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/auth")]
public class AuthController(IConfiguration configuration, ICadUsuarioRepository cadUsuariosRepository, Service service) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestViewModel requestViewModel, CancellationToken cancellationToken)
    {
        var model = await cadUsuariosRepository.GetHashPassWordAsync(email: requestViewModel.Email, cancellationToken);

        if (HashPassword.Verify(model.PasswordHash, requestViewModel.Senha))
        {
            var token = await service.GenerateJwtToken(model, configuration);
            return Ok(new { Token = token });
        }

        return Unauthorized(new { Message = "Invalid credentials" });
    }
}
