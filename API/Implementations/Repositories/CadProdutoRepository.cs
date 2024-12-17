using API.Implementations.Interfaces;
using API.Models;
using Infrastructure.Base.Implementations.Repositories;
using Infrastructure.DataBase;

namespace API.Implementations.Repositories;

public class CadProdutoRepository(DataBaseContext context) : BaseRepository<CadProduto>(context), ICadProdutoRepository
{
}
