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
    public class PessoaTipoController : ControllerBase
    {
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Consultar tipo de Pessoa pelo Id",
            Description = "[pt-BR] Consultar tipo de Pessoa pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Consult Person type by Id. Authentication token is required.",
            Tags = new[] { "PessoaTipo" }
        )]
        [ProducesResponseType(typeof(PessoaTipoTransfer), 200)]
        [ProducesResponseType(typeof(PessoaTipoTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult ConsultarPorId(int id)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                if (id > 0) {
                    pessoaTipo = pessoaTipoModel.ConsultarPorId(id);
                } else {
                    pessoaTipo = null;
                }
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();
                
                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoController ConsultarPorId [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            pessoaTipo.TratarLinks();

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return BadRequest(pessoaTipo);
            } else {
                return Ok(pessoaTipo);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar tipos de Pessoa",
            Description = "[pt-BR] Listar tipos de Pessoa. Requer token de autenticação. \n\n " +
                "[en-US] List Person types. Authentication token is required.",
            Tags = new[] { "PessoaTipo" }
        )]
        [ProducesResponseType(typeof(PessoaTipoTransfer), 200)]
        [ProducesResponseType(typeof(PessoaTipoTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Listar()
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipoLista;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoLista = pessoaTipoModel.Consultar(new PessoaTipoTransfer());
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirMensagem("Erro em PessoaTipoController Listar [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            pessoaTipoLista.TratarLinks();

            if (pessoaTipoLista.Erro || !pessoaTipoLista.Validacao) {
                return BadRequest(pessoaTipoLista);
            } else {
                return Ok(pessoaTipoLista);
            }
        }

        [HttpPost("lista")]
        [SwaggerOperation(
            Summary = "Filtrar tipos de Pessoa",
            Description = "[pt-BR] Filtrar tipos de Pessoa. Requer token de autenticação. \n\n " +
                "[en-US] Filter Person types. Authentication token is required.",
            Tags = new[] { "PessoaTipo" }
        )]
        [ProducesResponseType(typeof(PessoaTipoTransfer), 200)]
        [ProducesResponseType(typeof(PessoaTipoTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Consultar(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipoLista;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoLista = pessoaTipoModel.Consultar(pessoaTipoTransfer);
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirMensagem("Erro em PessoaTipoController Consultar [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            pessoaTipoLista.TratarLinks();

            if (pessoaTipoLista.Erro || !pessoaTipoLista.Validacao) {
                return BadRequest(pessoaTipoLista);
            } else {
                return Ok(pessoaTipoLista);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir tipo de Pessoa",
            Description = "[pt-BR] Incluir tipo de Pessoa. Requer token de autenticação. \n\n " +
                "[en-US] Add Person type. Authentication token is required.",
            Tags = new[] { "PessoaTipo" }
        )]
        [ProducesResponseType(typeof(PessoaTipoTransfer), 201)]
        [ProducesResponseType(typeof(PessoaTipoTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Incluir(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipo = pessoaTipoModel.Incluir(pessoaTipoTransfer);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoController Incluir [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            pessoaTipo.TratarLinks();

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return BadRequest(pessoaTipo);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = pessoaTipo.PessoaTipo.Id });

                return Created(uri, pessoaTipo);
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Alterar tipo de Pessoa",
            Description = "[pt-BR] Alterar tipo de Pessoa. Requer token de autenticação. \n\n " +
                "[en-US] Update Person type. Authentication token is required.",
            Tags = new[] { "PessoaTipo" }
        )]
        [ProducesResponseType(typeof(PessoaTipoTransfer), 200)]
        [ProducesResponseType(typeof(PessoaTipoTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Alterar(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipo = pessoaTipoModel.Alterar(pessoaTipoTransfer);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoController Alterar [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            pessoaTipo.TratarLinks();

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return BadRequest(pessoaTipo);
            } else {
                return Ok(pessoaTipo);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir tipo de Pessoa pelo Id",
            Description = "[pt-BR] Excluir tipo de Pessoa pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Delete Person type by Id. Authentication token is required.",
            Tags = new[] { "PessoaTipo" }
        )]
        [ProducesResponseType(typeof(PessoaTipoTransfer), 200)]
        [ProducesResponseType(typeof(PessoaTipoTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Excluir(int id)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipo = pessoaTipoModel.Excluir(id);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoController Excluir [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            pessoaTipo.TratarLinks();

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return BadRequest(pessoaTipo);
            } else {
                return Ok(pessoaTipo);
            }
        }
    }
}
