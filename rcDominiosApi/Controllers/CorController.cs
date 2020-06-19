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
    public class CorController : ControllerBase
    {
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Consultar Cor pelo Id",
            Description = "[pt-BR] Consultar Cor pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Consult Color by Id. Authentication token is required.",
            Tags = new[] { "Cor" }
        )]
        [ProducesResponseType(typeof(CorTransfer), 200)]
        [ProducesResponseType(typeof(CorTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult ConsultarPorId(int id)
        {
            CorModel corModel;
            CorTransfer cor;

            try {
                corModel = new CorModel();

                if (id > 0) {
                    cor = corModel.ConsultarPorId(id);
                } else {
                    cor = null;
                }
            } catch (Exception ex) {
                cor = new CorTransfer();
                
                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorController ConsultarPorId [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            cor.TratarLinks();

            if (cor.Erro || !cor.Validacao) {
                return BadRequest(cor);
            } else {
                return Ok(cor);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar Cores",
            Description = "[pt-BR] Listar Cores. Requer token de autenticação. \n\n " +
                "[en-US] List Colors. Authentication token is required.",
            Tags = new[] { "Cor" }
        )]
        [ProducesResponseType(typeof(CorTransfer), 200)]
        [ProducesResponseType(typeof(CorTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Listar()
        {
            CorModel corModel;
            CorTransfer corLista;

            try {
                corModel = new CorModel();

                corLista = corModel.Consultar(new CorTransfer());
            } catch (Exception ex) {
                corLista = new CorTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.IncluirMensagem("Erro em CorController Listar [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            corLista.TratarLinks();

            if (corLista.Erro || !corLista.Validacao) {
                return BadRequest(corLista);
            } else {
                return Ok(corLista);
            }
        }

        [HttpPost("lista")]
        [SwaggerOperation(
            Summary = "Filtrar Cores",
            Description = "[pt-BR] Filtrar Cores. Requer token de autenticação. \n\n " +
                "[en-US] Filter Colors. Authentication token is required.",
            Tags = new[] { "Cor" }
        )]
        [ProducesResponseType(typeof(CorTransfer), 200)]
        [ProducesResponseType(typeof(CorTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Consultar(CorTransfer corTransfer)
        {
            CorModel corModel;
            CorTransfer corLista;

            try {
                corModel = new CorModel();

                corLista = corModel.Consultar(corTransfer);
            } catch (Exception ex) {
                corLista = new CorTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.IncluirMensagem("Erro em CorController Consultar [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            corLista.TratarLinks();

            if (corLista.Erro || !corLista.Validacao) {
                return BadRequest(corLista);
            } else {
                return Ok(corLista);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir Cor",
            Description = "[pt-BR] Incluir Cor. Requer token de autenticação. \n\n " +
                "[en-US] Add Color. Authentication token is required.",
            Tags = new[] { "Cor" }
        )]
        [ProducesResponseType(typeof(CorTransfer), 201)]
        [ProducesResponseType(typeof(CorTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Incluir(CorTransfer corTransfer)
        {
            CorModel corModel;
            CorTransfer cor;

            try {
                corModel = new CorModel();

                cor = corModel.Incluir(corTransfer);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorController Incluir [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            cor.TratarLinks();

            if (cor.Erro || !cor.Validacao) {
                return BadRequest(cor);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = cor.Cor.Id });

                return Created(uri, cor);
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Alterar Cor",
            Description = "[pt-BR] Alterar Cor. Requer token de autenticação. \n\n " +
                "[en-US] Update Color. Authentication token is required.",
            Tags = new[] { "Cor" }
        )]
        [ProducesResponseType(typeof(CorTransfer), 200)]
        [ProducesResponseType(typeof(CorTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Alterar(CorTransfer corTransfer)
        {
            CorModel corModel;
            CorTransfer cor;

            try {
                corModel = new CorModel();

                cor = corModel.Alterar(corTransfer);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorController Alterar [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            cor.TratarLinks();

            if (cor.Erro || !cor.Validacao) {
                return BadRequest(cor);
            } else {
                return Ok(cor);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir Cor pelo Id",
            Description = "[pt-BR] Excluir Cor pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Delete Color by Id. Authentication token is required.",
            Tags = new[] { "Cor" }
        )]
        [ProducesResponseType(typeof(CorTransfer), 200)]
        [ProducesResponseType(typeof(CorTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Excluir(int id)
        {
            CorModel corModel;
            CorTransfer cor;

            try {
                corModel = new CorModel();

                cor = corModel.Excluir(id);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorController Excluir [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            cor.TratarLinks();

            if (cor.Erro || !cor.Validacao) {
                return BadRequest(cor);
            } else {
                return Ok(cor);
            }
        }
    }
}
