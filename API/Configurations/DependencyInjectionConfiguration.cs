using API.Implementations.Interfaces;
using API.Implementations.Repositories;
using API.Services.JwtToken;

namespace API.Configurations;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddRepositoryInjections(this IServiceCollection services)
    {
        services.AddScoped<ICadProdutoRepository, CadProdutoRepository>();
        services.AddScoped<ICadUsuarioRepository, CadUsuarioRepository>();

        services.AddScoped<ICadVisitanteRepository, CadVisitanteRepository>();
        services.AddScoped<ICadEnderecoRepository, CadEnderecoRepository>();

        services.AddScoped<Service>();

        return services;
    }
}
