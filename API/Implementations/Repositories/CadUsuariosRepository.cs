using API.Implementations.Interfaces;
using API.Models;
using Infrastructure.Base.Implementations.Repositories;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace API.Implementations.Repositories;

public class CadUsuariosRepository(DataBaseContext context, ILogger<BaseRepository<CadUsuarios>> logger) : BaseRepository<CadUsuarios>(context, logger), ICadUsuariosRepository
{
    private new readonly DbSet<CadUsuarios> _dbSet = context.GetDbSet<CadUsuarios>();

    public async Task<CadUsuarios> GetHashPassWordAsync(string email, CancellationToken cancellationToken)
        => await _dbSet.SingleAsync(w => w.Email == email, cancellationToken);
}
