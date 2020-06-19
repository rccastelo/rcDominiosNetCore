using System;
using System.Text;
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
    public class ContaBancariaController : ControllerBase
    {
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Consultar tipo de Conta Bancária pelo Id",
            Description = "[pt-BR] Consultar tipo de Conta Bancária pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Consult Bank Account type by Id. Authentication token is required.",
            Tags = new[] { "ContaBancaria" }
        )]
        [ProducesResponseType(typeof(ContaBancariaTransfer), 200)]
        [ProducesResponseType(typeof(ContaBancariaTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult ConsultarPorId(int id)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaModel = new ContaBancariaModel();

                if (id > 0) {
                    contaBancaria = contaBancariaModel.ConsultarPorId(id);
                } else {
                    contaBancaria = null;
                }
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();
                
                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaController ConsultarPorId [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            contaBancaria.TratarLinks();

            if (contaBancaria.Erro || !contaBancaria.Validacao) {
                return BadRequest(contaBancaria);
            } else {
                return Ok(contaBancaria);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar tipos de Conta Bancária",
            Description = "[pt-BR] Listar tipos de Conta Bancária. Requer token de autenticação. \n\n " +
                "[en-US] List Bank Account types. Authentication token is required.",
            Tags = new[] { "ContaBancaria" }
        )]
        [ProducesResponseType(typeof(ContaBancariaTransfer), 200)]
        [ProducesResponseType(typeof(ContaBancariaTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Listar()
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancariaLista;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancariaLista = contaBancariaModel.Consultar(new ContaBancariaTransfer());
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaTransfer();

                contaBancariaLista.Validacao = false;
                contaBancariaLista.Erro = true;
                contaBancariaLista.IncluirMensagem("Erro em ContaBancariaController Listar [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            contaBancariaLista.TratarLinks();

            if (contaBancariaLista.Erro || !contaBancariaLista.Validacao) {
                return BadRequest(contaBancariaLista);
            } else {
                return Ok(contaBancariaLista);
            }
        }

        [HttpPost("lista")]
        public IActionResult Consultar(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancariaLista;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancariaLista = contaBancariaModel.Consultar(contaBancariaTransfer);
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaTransfer();

                contaBancariaLista.Validacao = false;
                contaBancariaLista.Erro = true;
                contaBancariaLista.IncluirMensagem("Erro em ContaBancariaController Consultar [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            contaBancariaLista.TratarLinks();

            if (contaBancariaLista.Erro || !contaBancariaLista.Validacao) {
                return BadRequest(contaBancariaLista);
            } else {
                return Ok(contaBancariaLista);
            }
        }

        [HttpPost]
        public IActionResult Incluir(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancaria = contaBancariaModel.Incluir(contaBancariaTransfer);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaController Incluir [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            contaBancaria.TratarLinks();

            if (contaBancaria.Erro || !contaBancaria.Validacao) {
                return BadRequest(contaBancaria);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = contaBancaria.ContaBancaria.Id });

                return Created(uri, contaBancaria);
            }
        }

        [HttpPut]
        public IActionResult Alterar(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancaria = contaBancariaModel.Alterar(contaBancariaTransfer);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaController Alterar [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            contaBancaria.TratarLinks();

            if (contaBancaria.Erro || !contaBancaria.Validacao) {
                return BadRequest(contaBancaria);
            } else {
                return Ok(contaBancaria);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancaria = contaBancariaModel.Excluir(id);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaController Excluir [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            contaBancaria.TratarLinks();

            if (contaBancaria.Erro || !contaBancaria.Validacao) {
                return BadRequest(contaBancaria);
            } else {
                return Ok(contaBancaria);
            }
        }
    }
}
