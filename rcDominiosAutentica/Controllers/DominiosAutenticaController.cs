using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace rcDominiosAutentica.Controllers
{
    [ApiController]
    [Route("")]
    public class DominiosAutenticaController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "API de autenticação para o sistema de gerenciamento de domínios",
            Description = "[pt-BR] API de autenticação para o sistema de gerenciamento de domínios. \n\n " +
                "[en-US] Authentication API for the domain management system. ",
            Tags = new[] { "rcDominiosAutentica" }
        )]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
