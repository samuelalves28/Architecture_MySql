using API.Implementations.Interfaces;
using API.Models;
using Infraestrutura.Base.Implementations.Repositories;
using Infraestrutura.DataBase;
using Microsoft.EntityFrameworkCore;

namespace API.Implementations.Repositories;

public class CadUsuarioRepository(DataBaseContext context, ILogger<BaseRepository<CadUsuario>> logger) : BaseRepository<CadUsuario>(context, logger), ICadUsuarioRepository
{
    private new readonly DbSet<CadUsuario> _dbSet = context.GetDbSet<CadUsuario>();

    public async Task<CadUsuario> GetHashPassWordAsync(string email, CancellationToken cancellationToken)
        => await _dbSet.SingleAsync(w => w.Email == email, cancellationToken);
}
