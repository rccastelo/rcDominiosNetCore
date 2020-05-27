using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using rcDominiosTransfers;

namespace rcDominiosAutentica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Autoriza(AutenticaTransfer autenticaTransfer) 
        {
            bool valido = false;
            AutenticaTransfer autentica = null;

            try {
                autentica = new AutenticaTransfer(autenticaTransfer);
                autentica.Senha = "";

                if ((autenticaTransfer != null) && (autenticaTransfer is AutenticaTransfer)) {
                    if ((autenticaTransfer.Apelido == "admin") && (autenticaTransfer.Senha == "senha")) {
                        valido = true;
                    }
                }

                if (valido) {
                    var direitos = new [] {
                        new Claim(JwtRegisteredClaimNames.Sub, autenticaTransfer.Apelido),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("rc-Dominios-Autenticacao"));

                    var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                    var jwtSecurityToken = new JwtSecurityToken(
                        issuer: "rcDominiosAutentica",
                        audience: "Postman",
                        claims: direitos,
                        signingCredentials: credenciais,
                        expires: DateTime.Now.AddMinutes(30)
                    );

                    string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                    autentica.Token = token;
                    autentica.Autenticado = true;
                    autentica.Erro = false;
                    autentica.Validacao = true;

                    return Ok(autentica);
                } else {
                    autentica = new AutenticaTransfer(autenticaTransfer);

                    autentica.Autenticado = false;
                    autentica.Token = "";
                    autentica.Validacao = false;

                    autentica.IncluirValidacaoMensagem("Usuário e/ou senha informado(s) inválido(s)");

                    return Unauthorized(autentica);
                }
            } catch {
                return BadRequest(autentica);
            }
        }
    }
}
