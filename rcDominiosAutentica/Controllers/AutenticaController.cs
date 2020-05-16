using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using rcDominiosDataTransfers;

namespace rcDominiosAutentica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Index(UsuarioRequest usuario) 
        {
            bool valido = false;

            try {
                if ((usuario != null) && (usuario is UsuarioRequest)) {
                    if ((usuario.Apelido == "admin") && (usuario.Senha == "senha")) {
                        valido = true;
                    }
                }

                if (valido) {
                    var direitos = new [] {
                        new Claim(JwtRegisteredClaimNames.Sub, usuario.Apelido),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("rc-Dominios-Autenticacao"));

                    var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "rcDominiosAutentica",
                        audience: "Postman",
                        claims: direitos,
                        signingCredentials: credenciais,
                        expires: DateTime.Now.AddMinutes(30)
                    );

                    var segredo = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(segredo);
                } else {
                    return Unauthorized();
                }
            } catch {
                return BadRequest();
            }
        }
    }
}
