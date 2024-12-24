using API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services.JwtToken;

public class Service
{
    public async Task<string> GenerateJwtToken(CadUsuario cadUsuario, IConfiguration configuration)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, cadUsuario.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Email, cadUsuario.Email),
            new Claim(ClaimTypes.Name, cadUsuario.Nome)
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

