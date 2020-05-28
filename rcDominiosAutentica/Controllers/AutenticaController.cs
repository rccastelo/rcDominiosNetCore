using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using rcDominiosApi.Models;
using rcDominiosTransfers;

namespace rcDominiosAutentica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticaController : ControllerBase
    {
        [HttpPost]
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
