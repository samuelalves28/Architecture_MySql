using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Implementations.Interfaces;
using API.ViewModels;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers;

[Route("api/auth")]
public class AuthController(IConfiguration configuration, ICadUsuariosRepository cadUsuariosRepository) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestViewModel requestViewModel, CancellationToken cancellationToken)
    {
        var model = await cadUsuariosRepository.GetHashPassWordAsync(email: requestViewModel.Email, cancellationToken);

        if (HashPassword.Verify(model.PasswordHash, requestViewModel.Senha))
        {
            var token = GenerateJwtToken(requestViewModel.Email);
            return Ok(new { Token = token });
        }

        return Unauthorized(new { Message = "Invalid credentials" });
    }

    // Jogar isso aqui para uma service
    private string GenerateJwtToken(string username)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, username),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenConfiguration:IssuerSigningKey"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["TokenConfiguration:Issuer"],
            audience: configuration["TokenConfiguration:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
