using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace rcDominiosApi.Controllers
{
    [ApiController]
    [Route("")]
    public class DominiosApiController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "API para gerenciamento das informações dos domínios.",
            Description = "[pt-BR] API para gerenciamento das informações dos domínios. \n\n " +
                "[en-US] API for managing domain information. ",
            Tags = new[] { "rcDominiosApi" }
        )]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }        
    }
}
