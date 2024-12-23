using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Base.Controller;

public class AuthBaseController
{

    [ApiController]
    public abstract class BaseController() : ControllerBase
    {
    }

    [Authorize]
    public abstract class AuthBSController : ControllerBase
    {
        protected IActionResult ForbiddenResponse()
        {
            return Forbid();
        }

        protected IActionResult UnauthorizedResponse()
        {
            return Unauthorized(new { message = "Autenticação necessária para acessar este recurso." });
        }
    }
}
