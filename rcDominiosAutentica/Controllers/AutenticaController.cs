using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosTransfers;
using Swashbuckle.AspNetCore.Annotations;

namespace rcDominiosAutentica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticaController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(
            Summary = "Autenticar usuário",
            Description = "[pt-BR] Autenticar usuário. \n\n " +
                "[en-US] User authentication.",
            Tags = new[] { "Autentica" }
        )]
        [ProducesResponseType(typeof(AutenticaTransfer), 200)]
        [ProducesResponseType(typeof(AutenticaTransfer), 400)]
        [ProducesResponseType(typeof(AutenticaTransfer), 401)]
        [ProducesResponseType(500)]
        public IActionResult Autenticar(AutenticaTransfer autenticaTransfer) 
        {
            AutenticaModel autenticaModel = null;
            AutenticaTransfer autentica = null;

            try {
                autenticaModel = new AutenticaModel();

                autentica = autenticaModel.Autenticar(autenticaTransfer);

                if (!autentica.Erro) {
                    if (autentica.Autenticado) {
                        return Ok(autentica);
                    } else {
                        return Unauthorized(autentica);
                    }
                } else {
                    return BadRequest(autentica);
                }
            } catch (Exception ex) {
                autentica = new AutenticaTransfer();

                autentica.Erro = true;
                autentica.IncluirMensagem("Erro em AutenticaController Autenticar [" + ex.Message + "]");

                return BadRequest(autentica);
            } finally {
                autenticaModel = null;
            }
        }
    }
}
