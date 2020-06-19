using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace rcDominiosApi.Controllers
{
    [ApiController]
    [Route("")]
    public class DominiosController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "API de Domínios",
            Description = "[pt-BR] API de Domínios. \n\n " +
                "[en-US] Domains API. ",
            Tags = new[] { "Domínios" }
        )]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }        
    }
}
