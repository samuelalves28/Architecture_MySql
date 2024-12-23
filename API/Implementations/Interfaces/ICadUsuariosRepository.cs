using API.Models;
using Infrastructure.Base.Implementations.Interface;

namespace API.Implementations.Interfaces;

public interface ICadUsuariosRepository : IBaseRepository<CadUsuarios>
{
    public Task<CadUsuarios> GetHashPassWordAsync(string email, CancellationToken cancellationToken);
}
