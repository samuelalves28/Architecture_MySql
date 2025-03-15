using API.Implementations.Interfaces;
using API.Models;
using Infraestrutura.Base.Implementations.Repositories;
using Infraestrutura.DataBase;

namespace API.Implementations.Repositories;

public class CadVisitanteRepository(DataBaseContext context, ILogger<BaseRepository<CadVisitante>> logger) : BaseRepository<CadVisitante>(context, logger), ICadVisitanteRepository
{

}
