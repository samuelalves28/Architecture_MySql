using API.Implementations.Interfaces;
using API.Models;
using Infraestrutura.Base.Implementations.Repositories;
using Infraestrutura.DataBase;

namespace API.Implementations.Repositories;

public class CadEnderecoRepository(DataBaseContext context, ILogger<BaseRepository<CadEndereco>> logger) : BaseRepository<CadEndereco>(context, logger), ICadEnderecoRepository
{
}
