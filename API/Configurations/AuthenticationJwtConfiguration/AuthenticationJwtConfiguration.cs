using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Configurations.AuthenticationJwtConfiguration;
public static class AuthenticationJwtConfiguration
{
    public static IServiceCollection AddAuthenticationJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var tokenConfigSection = configuration.GetSection("TokenConfiguration");
        services.Configure<TokenConfiguration>(tokenConfigSection);

        var tokenConfiguration = tokenConfigSection.Get<TokenConfiguration>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenConfiguration!.Issuer,
                    ValidAudience = tokenConfiguration.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.IssuerSigningKey))
                };
            });

        services.AddAuthorization();

        return services;
    }
}
