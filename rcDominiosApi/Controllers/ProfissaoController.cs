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
    public class ProfissaoController : ControllerBase
    {
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Consultar Profissão pelo Id",
            Description = "[pt-BR] Consultar Profissão pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Consult Profession by Id. Authentication token is required.",
            Tags = new[] { "Profissao" }
        )]
        [ProducesResponseType(typeof(ProfissaoTransfer), 200)]
        [ProducesResponseType(typeof(ProfissaoTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult ConsultarPorId(int id)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel();

                if (id > 0) {
                    profissao = profissaoModel.ConsultarPorId(id);
                } else {
                    profissao = null;
                }
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();
                
                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoController ConsultarPorId [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            profissao.TratarLinks();

            if (profissao.Erro || !profissao.Validacao) {
                return BadRequest(profissao);
            } else {
                return Ok(profissao);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar Profissão",
            Description = "[pt-BR] Listar Profissão. Requer token de autenticação. \n\n " +
                "[en-US] List Profession. Authentication token is required.",
            Tags = new[] { "Profissao" }
        )]
        [ProducesResponseType(typeof(ProfissaoTransfer), 200)]
        [ProducesResponseType(typeof(ProfissaoTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Listar()
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissaoLista;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoLista = profissaoModel.Consultar(new ProfissaoTransfer());
            } catch (Exception ex) {
                profissaoLista = new ProfissaoTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirMensagem("Erro em ProfissaoController Listar [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            profissaoLista.TratarLinks();

            if (profissaoLista.Erro || !profissaoLista.Validacao) {
                return BadRequest(profissaoLista);
            } else {
                return Ok(profissaoLista);
            }
        }

        [HttpPost("lista")]
        public IActionResult Consultar(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissaoLista;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoLista = profissaoModel.Consultar(profissaoTransfer);
            } catch (Exception ex) {
                profissaoLista = new ProfissaoTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirMensagem("Erro em ProfissaoController Consultar [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            profissaoLista.TratarLinks();

            if (profissaoLista.Erro || !profissaoLista.Validacao) {
                return BadRequest(profissaoLista);
            } else {
                return Ok(profissaoLista);
            }
        }

        [HttpPost]
        public IActionResult Incluir(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel();

                profissao = profissaoModel.Incluir(profissaoTransfer);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoController Incluir [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            profissao.TratarLinks();

            if (profissao.Erro || !profissao.Validacao) {
                return BadRequest(profissao);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = profissao.Profissao.Id });

                return Created(uri, profissao);
            }
        }

        [HttpPut]
        public IActionResult Alterar(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel();

                profissao = profissaoModel.Alterar(profissaoTransfer);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoController Alterar [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            profissao.TratarLinks();

            if (profissao.Erro || !profissao.Validacao) {
                return BadRequest(profissao);
            } else {
                return Ok(profissao);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel();

                profissao = profissaoModel.Excluir(id);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoController Excluir [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            profissao.TratarLinks();

            if (profissao.Erro || !profissao.Validacao) {
                return BadRequest(profissao);
            } else {
                return Ok(profissao);
            }
        }
    }
}
