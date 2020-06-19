using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosTransfers;
using Swashbuckle.AspNetCore.Annotations;

namespace rcDominiosApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GeneroSocialController : ControllerBase
    {
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Consultar Gênero Social pelo Id",
            Description = "[pt-BR] Consultar Gênero Social pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Consult Social Gender by Id. Authentication token is required.",
            Tags = new[] { "GeneroSocial" }
        )]
        [ProducesResponseType(typeof(GeneroSocialTransfer), 200)]
        [ProducesResponseType(typeof(GeneroSocialTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult ConsultarPorId(int id)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel();

                if (id > 0) {
                    generoSocial = generoSocialModel.ConsultarPorId(id);
                } else {
                    generoSocial = null;
                }
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();
                
                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialController ConsultarPorId [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            generoSocial.TratarLinks();

            if (generoSocial.Erro || !generoSocial.Validacao) {
                return BadRequest(generoSocial);
            } else {
                return Ok(generoSocial);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar Gênero Social",
            Description = "[pt-BR] Listar Gênero Social. Requer token de autenticação. \n\n " +
                "[en-US] List Social Gender. Authentication token is required.",
            Tags = new[] { "GeneroSocial" }
        )]
        [ProducesResponseType(typeof(GeneroSocialTransfer), 200)]
        [ProducesResponseType(typeof(GeneroSocialTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Listar()
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocialLista;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialLista = generoSocialModel.Consultar(new GeneroSocialTransfer());
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.IncluirMensagem("Erro em GeneroSocialController Listar [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            generoSocialLista.TratarLinks();

            if (generoSocialLista.Erro || !generoSocialLista.Validacao) {
                return BadRequest(generoSocialLista);
            } else {
                return Ok(generoSocialLista);
            }
        }

        [HttpPost("lista")]
        [SwaggerOperation(
            Summary = "Filtrar Gênero Social",
            Description = "[pt-BR] Filtrar Gênero Social. Requer token de autenticação. \n\n " +
                "[en-US] Filter Social Gender. Authentication token is required.",
            Tags = new[] { "GeneroSocial" }
        )]
        [ProducesResponseType(typeof(GeneroSocialTransfer), 200)]
        [ProducesResponseType(typeof(GeneroSocialTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Consultar(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocialLista;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialLista = generoSocialModel.Consultar(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.IncluirMensagem("Erro em GeneroSocialController Consultar [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            generoSocialLista.TratarLinks();

            if (generoSocialLista.Erro || !generoSocialLista.Validacao) {
                return BadRequest(generoSocialLista);
            } else {
                return Ok(generoSocialLista);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir Gênero Social",
            Description = "[pt-BR] Incluir Gênero Social. Requer token de autenticação. \n\n " +
                "[en-US] Add Social Gender. Authentication token is required.",
            Tags = new[] { "GeneroSocial" }
        )]
        [ProducesResponseType(typeof(GeneroSocialTransfer), 201)]
        [ProducesResponseType(typeof(GeneroSocialTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Incluir(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocial = generoSocialModel.Incluir(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialController Incluir [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            generoSocial.TratarLinks();

            if (generoSocial.Erro || !generoSocial.Validacao) {
                return BadRequest(generoSocial);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = generoSocial.GeneroSocial.Id });

                return Created(uri, generoSocial);
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Alterar Gênero Social",
            Description = "[pt-BR] Alterar Gênero Social. Requer token de autenticação. \n\n " +
                "[en-US] Update Social Gender. Authentication token is required.",
            Tags = new[] { "GeneroSocial" }
        )]
        [ProducesResponseType(typeof(GeneroSocialTransfer), 200)]
        [ProducesResponseType(typeof(GeneroSocialTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Alterar(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocial = generoSocialModel.Alterar(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialController Alterar [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            generoSocial.TratarLinks();

            if (generoSocial.Erro || !generoSocial.Validacao) {
                return BadRequest(generoSocial);
            } else {
                return Ok(generoSocial);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir Gênero Social pelo Id",
            Description = "[pt-BR] Excluir Gênero Social pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Delete Social Gender by Id. Authentication token is required.",
            Tags = new[] { "GeneroSocial" }
        )]
        [ProducesResponseType(typeof(GeneroSocialTransfer), 200)]
        [ProducesResponseType(typeof(GeneroSocialTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Excluir(int id)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocial = generoSocialModel.Excluir(id);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialController Excluir [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            generoSocial.TratarLinks();

            if (generoSocial.Erro || !generoSocial.Validacao) {
                return BadRequest(generoSocial);
            } else {
                return Ok(generoSocial);
            }
        }
    }
}
