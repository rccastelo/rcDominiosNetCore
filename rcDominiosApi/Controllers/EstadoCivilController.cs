using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosDataTransfers;

namespace rcDominiosApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EstadoCivilController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilDataTransfer estadoCivilForm;

            try {
                estadoCivilModel = new EstadoCivilModel();

                if (id > 0) {
                    estadoCivilForm = estadoCivilModel.ConsultarPorId(id);
                } else {
                    estadoCivilForm = null;
                }
            } catch (Exception ex) {
                estadoCivilForm = new EstadoCivilDataTransfer();
                
                estadoCivilForm.Validacao = false;
                estadoCivilForm.Erro = true;
                estadoCivilForm.IncluirErroMensagem("Erro em EstadoCivilController ConsultarPorId [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivilForm.Erro || !estadoCivilForm.Validacao) {
                return BadRequest(estadoCivilForm);
            } else {
                return Ok(estadoCivilForm);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilDataTransfer estadoCivilLista;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivilLista = estadoCivilModel.Listar();
            } catch (Exception ex) {
                estadoCivilLista = new EstadoCivilDataTransfer();

                estadoCivilLista.Validacao = false;
                estadoCivilLista.Erro = true;
                estadoCivilLista.IncluirErroMensagem("Erro em EstadoCivilController Listar [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivilLista.Erro || !estadoCivilLista.Validacao) {
                return BadRequest(estadoCivilLista);
            } else {
                return Ok(estadoCivilLista);
            }
        }

        [HttpPost]
        public IActionResult Incluir(EstadoCivilDataTransfer estadoCivilDataTransfer)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilDataTransfer estadoCivilRetorno;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivilRetorno = estadoCivilModel.Incluir(estadoCivilDataTransfer);
            } catch (Exception ex) {
                estadoCivilRetorno = new EstadoCivilDataTransfer();

                estadoCivilRetorno.Validacao = false;
                estadoCivilRetorno.Erro = true;
                estadoCivilRetorno.IncluirErroMensagem("Erro em EstadoCivilController Incluir [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivilRetorno.Erro || !estadoCivilRetorno.Validacao) {
                return BadRequest(estadoCivilRetorno);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = estadoCivilRetorno.EstadoCivil.Id });

                return Created(uri, estadoCivilRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alterar(EstadoCivilDataTransfer estadoCivilDataTransfer)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilDataTransfer estadoCivilRetorno;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivilRetorno = estadoCivilModel.Alterar(estadoCivilDataTransfer);
            } catch (Exception ex) {
                estadoCivilRetorno = new EstadoCivilDataTransfer();

                estadoCivilRetorno.Validacao = false;
                estadoCivilRetorno.Erro = true;
                estadoCivilRetorno.IncluirErroMensagem("Erro em EstadoCivilController Alterar [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivilRetorno.Erro || !estadoCivilRetorno.Validacao) {
                return BadRequest(estadoCivilRetorno);
            } else {
                return Ok(estadoCivilRetorno);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilDataTransfer estadoCivilRetorno;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivilRetorno = estadoCivilModel.Excluir(id);
            } catch (Exception ex) {
                estadoCivilRetorno = new EstadoCivilDataTransfer();

                estadoCivilRetorno.Validacao = false;
                estadoCivilRetorno.Erro = true;
                estadoCivilRetorno.IncluirErroMensagem("Erro em EstadoCivilController Excluir [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivilRetorno.Erro || !estadoCivilRetorno.Validacao) {
                return BadRequest(estadoCivilRetorno);
            } else {
                return NoContent();
            }
        }
    }
}
