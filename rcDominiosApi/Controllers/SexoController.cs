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
    public class SexoController : ControllerBase
    {
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Consultar Sexo pelo Id",
            Description = "[pt-BR] Consultar Sexo pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Consult Gender by Id. Authentication token is required.",
            Tags = new[] { "Sexo" }
        )]
        [ProducesResponseType(typeof(SexoTransfer), 200)]
        [ProducesResponseType(typeof(SexoTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult ConsultarPorId(int id)
        {
            SexoModel sexoModel;
            SexoTransfer sexo;

            try {
                sexoModel = new SexoModel();

                if (id > 0) {
                    sexo = sexoModel.ConsultarPorId(id);
                } else {
                    sexo = null;
                }
            } catch (Exception ex) {
                sexo = new SexoTransfer();
                
                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoController ConsultarPorId [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            sexo.TratarLinks();

            if (sexo.Erro || !sexo.Validacao) {
                return BadRequest(sexo);
            } else {
                return Ok(sexo);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar Sexo",
            Description = "[pt-BR] Listar Sexo. Requer token de autenticação. \n\n " +
                "[en-US] List Gender. Authentication token is required.",
            Tags = new[] { "Sexo" }
        )]
        [ProducesResponseType(typeof(SexoTransfer), 200)]
        [ProducesResponseType(typeof(SexoTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Listar()
        {
            SexoModel sexoModel;
            SexoTransfer sexoLista;

            try {
                sexoModel = new SexoModel();

                sexoLista = sexoModel.Consultar(new SexoTransfer());
            } catch (Exception ex) {
                sexoLista = new SexoTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.IncluirMensagem("Erro em SexoController Listar [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            sexoLista.TratarLinks();

            if (sexoLista.Erro || !sexoLista.Validacao) {
                return BadRequest(sexoLista);
            } else {
                return Ok(sexoLista);
            }
        }

        [HttpPost("lista")]
        public IActionResult Consultar(SexoTransfer sexoTransfer)
        {
            SexoModel sexoModel;
            SexoTransfer sexoLista;

            try {
                sexoModel = new SexoModel();

                sexoLista = sexoModel.Consultar(sexoTransfer);
            } catch (Exception ex) {
                sexoLista = new SexoTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.IncluirMensagem("Erro em SexoController Consultar [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            sexoLista.TratarLinks();

            if (sexoLista.Erro || !sexoLista.Validacao) {
                return BadRequest(sexoLista);
            } else {
                return Ok(sexoLista);
            }
        }

        [HttpPost]
        public IActionResult Incluir(SexoTransfer sexoTransfer)
        {
            SexoModel sexoModel;
            SexoTransfer sexo;

            try {
                sexoModel = new SexoModel();

                sexo = sexoModel.Incluir(sexoTransfer);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoController Incluir [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            sexo.TratarLinks();

            if (sexo.Erro || !sexo.Validacao) {
                return BadRequest(sexo);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = sexo.Sexo.Id });

                return Created(uri, sexo);
            }
        }

        [HttpPut]
        public IActionResult Alterar(SexoTransfer sexoTransfer)
        {
            SexoModel sexoModel;
            SexoTransfer sexo;

            try {
                sexoModel = new SexoModel();

                sexo = sexoModel.Alterar(sexoTransfer);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoController Alterar [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            sexo.TratarLinks();

            if (sexo.Erro || !sexo.Validacao) {
                return BadRequest(sexo);
            } else {
                return Ok(sexo);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            SexoModel sexoModel;
            SexoTransfer sexo;

            try {
                sexoModel = new SexoModel();

                sexo = sexoModel.Excluir(id);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoController Excluir [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            sexo.TratarLinks();

            if (sexo.Erro || !sexo.Validacao) {
                return BadRequest(sexo);
            } else {
                return Ok(sexo);
            }
        }
    }
}
