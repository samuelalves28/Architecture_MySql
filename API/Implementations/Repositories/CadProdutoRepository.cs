using API.Implementations.Interfaces;
using API.Models;
using Infraestrutura.Base.Implementations.Repositories;
using Infraestrutura.DataBase;

namespace API.Implementations.Repositories;

public class CadProdutoRepository(DataBaseContext context, ILogger<BaseRepository<CadProduto>> logger) : BaseRepository<CadProduto>(context, logger), ICadProdutoRepository
{
}
