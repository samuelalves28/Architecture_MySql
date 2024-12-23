using API.Implementations.Interfaces;
using API.Models;
using Infrastructure.Base.Implementations.Repositories;
using Infrastructure.DataBase;

namespace API.Implementations.Repositories;

public class CadUsuariosRepository(DataBaseContext context, ILogger<BaseRepository<CadUsuarios>> logger) : BaseRepository<CadUsuarios>(context, logger), ICadUsuariosRepository
{
}
