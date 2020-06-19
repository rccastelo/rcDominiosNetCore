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
    public class TelefoneTipoController : ControllerBase
    {
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Consultar tipo de Telefone pelo Id",
            Description = "[pt-BR] Consultar tipo de Telefone pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Consult Phone type by Id. Authentication token is required.",
            Tags = new[] { "TelefoneTipo" }
        )]
        [ProducesResponseType(typeof(TelefoneTipoTransfer), 200)]
        [ProducesResponseType(typeof(TelefoneTipoTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult ConsultarPorId(int id)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoTransfer telefoneTipo;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                if (id > 0) {
                    telefoneTipo = telefoneTipoModel.ConsultarPorId(id);
                } else {
                    telefoneTipo = null;
                }
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();
                
                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoController ConsultarPorId [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            telefoneTipo.TratarLinks();

            if (telefoneTipo.Erro || !telefoneTipo.Validacao) {
                return BadRequest(telefoneTipo);
            } else {
                return Ok(telefoneTipo);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar tipos de Telefone",
            Description = "[pt-BR] Listar tipos de Telefone. Requer token de autenticação. \n\n " +
                "[en-US] List Phone types. Authentication token is required.",
            Tags = new[] { "TelefoneTipo" }
        )]
        [ProducesResponseType(typeof(TelefoneTipoTransfer), 200)]
        [ProducesResponseType(typeof(TelefoneTipoTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Listar()
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoTransfer telefoneTipoLista;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipoLista = telefoneTipoModel.Consultar(new TelefoneTipoTransfer());
            } catch (Exception ex) {
                telefoneTipoLista = new TelefoneTipoTransfer();

                telefoneTipoLista.Validacao = false;
                telefoneTipoLista.Erro = true;
                telefoneTipoLista.IncluirMensagem("Erro em TelefoneTipoController Listar [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            telefoneTipoLista.TratarLinks();

            if (telefoneTipoLista.Erro || !telefoneTipoLista.Validacao) {
                return BadRequest(telefoneTipoLista);
            } else {
                return Ok(telefoneTipoLista);
            }
        }

        [HttpPost("lista")]
        public IActionResult Consultar(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoTransfer telefoneTipoLista;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipoLista = telefoneTipoModel.Consultar(telefoneTipoTransfer);
            } catch (Exception ex) {
                telefoneTipoLista = new TelefoneTipoTransfer();

                telefoneTipoLista.Validacao = false;
                telefoneTipoLista.Erro = true;
                telefoneTipoLista.IncluirMensagem("Erro em TelefoneTipoController Consultar [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            telefoneTipoLista.TratarLinks();

            if (telefoneTipoLista.Erro || !telefoneTipoLista.Validacao) {
                return BadRequest(telefoneTipoLista);
            } else {
                return Ok(telefoneTipoLista);
            }
        }

        [HttpPost]
        public IActionResult Incluir(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoTransfer telefoneTipo;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipo = telefoneTipoModel.Incluir(telefoneTipoTransfer);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoController Incluir [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            telefoneTipo.TratarLinks();

            if (telefoneTipo.Erro || !telefoneTipo.Validacao) {
                return BadRequest(telefoneTipo);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = telefoneTipo.TelefoneTipo.Id });

                return Created(uri, telefoneTipo);
            }
        }

        [HttpPut]
        public IActionResult Alterar(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoTransfer telefoneTipo;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipo = telefoneTipoModel.Alterar(telefoneTipoTransfer);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoController Alterar [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            telefoneTipo.TratarLinks();

            if (telefoneTipo.Erro || !telefoneTipo.Validacao) {
                return BadRequest(telefoneTipo);
            } else {
                return Ok(telefoneTipo);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoTransfer telefoneTipo;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipo = telefoneTipoModel.Excluir(id);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoController Excluir [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            telefoneTipo.TratarLinks();

            if (telefoneTipo.Erro || !telefoneTipo.Validacao) {
                return BadRequest(telefoneTipo);
            } else {
                return Ok(telefoneTipo);
            }
        }
    }
}
