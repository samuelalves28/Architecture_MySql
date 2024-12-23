using API.Implementations.Interfaces;
using API.Implementations.Repositories;

namespace API.Configurations;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddRepositoryInjections(this IServiceCollection services)
    {
        services.AddScoped<ICadProdutoRepository, CadProdutoRepository>();
        services.AddScoped<ICadUsuariosRepository, CadUsuariosRepository>();

        return services;
    }
}
