using API.Implementations.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CadVisitante;

[Route("api/cad-visitante")]
public class CadVisitanteController(ICadVisitanteRepository cadVisitanteRepository, ICadEnderecoRepository cadEnderecoRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        => Ok(await cadVisitanteRepository.GetAsync(cancellationToken));




}
