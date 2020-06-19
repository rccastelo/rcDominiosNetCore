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
    public class EstadoCivilController : ControllerBase
    {
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Consultar Estado Civil pelo Id",
            Description = "[pt-BR] Consultar Estado Civil pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Consult Marital status by Id. Authentication token is required.",
            Tags = new[] { "EstadoCivil" }
        )]
        [ProducesResponseType(typeof(EstadoCivilTransfer), 200)]
        [ProducesResponseType(typeof(EstadoCivilTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult ConsultarPorId(int id)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilModel = new EstadoCivilModel();

                if (id > 0) {
                    estadoCivil = estadoCivilModel.ConsultarPorId(id);
                } else {
                    estadoCivil = null;
                }
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();
                
                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilController ConsultarPorId [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            estadoCivil.TratarLinks();

            if (estadoCivil.Erro || !estadoCivil.Validacao) {
                return BadRequest(estadoCivil);
            } else {
                return Ok(estadoCivil);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar Estado Civil",
            Description = "[pt-BR] Listar Estado Civil. Requer token de autenticação. \n\n " +
                "[en-US] List Marital status. Authentication token is required.",
            Tags = new[] { "EstadoCivil" }
        )]
        [ProducesResponseType(typeof(EstadoCivilModel), 200)]
        [ProducesResponseType(typeof(EstadoCivilModel), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Listar()
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilTransfer estadoCivilLista;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivilLista = estadoCivilModel.Consultar(new EstadoCivilTransfer());
            } catch (Exception ex) {
                estadoCivilLista = new EstadoCivilTransfer();

                estadoCivilLista.Validacao = false;
                estadoCivilLista.Erro = true;
                estadoCivilLista.IncluirMensagem("Erro em EstadoCivilController Listar [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            estadoCivilLista.TratarLinks();

            if (estadoCivilLista.Erro || !estadoCivilLista.Validacao) {
                return BadRequest(estadoCivilLista);
            } else {
                return Ok(estadoCivilLista);
            }
        }

        [HttpPost("lista")]
        [SwaggerOperation(
            Summary = "Filtrar Estado Civil",
            Description = "[pt-BR] Filtrar Estado Civil. Requer token de autenticação. \n\n " +
                "[en-US] Filter Marital status. Authentication token is required.",
            Tags = new[] { "EstadoCivil" }
        )]
        [ProducesResponseType(typeof(EstadoCivilModel), 200)]
        [ProducesResponseType(typeof(EstadoCivilModel), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Consultar(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilTransfer estadoCivilLista;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivilLista = estadoCivilModel.Consultar(estadoCivilTransfer);
            } catch (Exception ex) {
                estadoCivilLista = new EstadoCivilTransfer();

                estadoCivilLista.Validacao = false;
                estadoCivilLista.Erro = true;
                estadoCivilLista.IncluirMensagem("Erro em EstadoCivilController Consultar [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            estadoCivilLista.TratarLinks();

            if (estadoCivilLista.Erro || !estadoCivilLista.Validacao) {
                return BadRequest(estadoCivilLista);
            } else {
                return Ok(estadoCivilLista);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir Estado Civil",
            Description = "[pt-BR] Incluir Estado Civil. Requer token de autenticação. \n\n " +
                "[en-US] Add Marital status. Authentication token is required.",
            Tags = new[] { "EstadoCivil" }
        )]
        [ProducesResponseType(typeof(EstadoCivilTransfer), 201)]
        [ProducesResponseType(typeof(EstadoCivilTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Incluir(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivil = estadoCivilModel.Incluir(estadoCivilTransfer);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilController Incluir [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            estadoCivil.TratarLinks();

            if (estadoCivil.Erro || !estadoCivil.Validacao) {
                return BadRequest(estadoCivil);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = estadoCivil.EstadoCivil.Id });

                return Created(uri, estadoCivil);
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Alterar Estado Civil",
            Description = "[pt-BR] Alterar Estado Civil. Requer token de autenticação. \n\n " +
                "[en-US] Update Marital status. Authentication token is required.",
            Tags = new[] { "EstadoCivil" }
        )]
        [ProducesResponseType(typeof(EstadoCivilTransfer), 200)]
        [ProducesResponseType(typeof(EstadoCivilTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Alterar(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivil = estadoCivilModel.Alterar(estadoCivilTransfer);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilController Alterar [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            estadoCivil.TratarLinks();

            if (estadoCivil.Erro || !estadoCivil.Validacao) {
                return BadRequest(estadoCivil);
            } else {
                return Ok(estadoCivil);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir Estado Civil pelo Id",
            Description = "[pt-BR] Excluir Estado Civil pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Delete Marital status by Id. Authentication token is required.",
            Tags = new[] { "EstadoCivil" }
        )]
        [ProducesResponseType(typeof(EstadoCivilTransfer), 200)]
        [ProducesResponseType(typeof(EstadoCivilTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Excluir(int id)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivil = estadoCivilModel.Excluir(id);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilController Excluir [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            estadoCivil.TratarLinks();

            if (estadoCivil.Erro || !estadoCivil.Validacao) {
                return BadRequest(estadoCivil);
            } else {
                return Ok(estadoCivil);
            }
        }
    }
}
