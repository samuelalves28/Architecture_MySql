﻿using API.Models;
using Infraestrutura.Base.Implementations.Interface;

namespace API.Implementations.Interfaces;

public interface ICadUsuarioRepository : IBaseRepository<CadUsuario>
{
    public Task<CadUsuario> GetHashPassWordAsync(string email, CancellationToken cancellationToken);
}
