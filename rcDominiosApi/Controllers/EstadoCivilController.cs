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
        public IActionResult Form(int id)
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
                estadoCivilForm.ErroMensagens.Add("Erro em EstadoCivilController Form [" + ex.Message + "]");
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
        public IActionResult Lista()
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
                estadoCivilLista.ErroMensagens.Add("Erro em EstadoCivilController Lista [" + ex.Message + "]");
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
        public IActionResult Inclusao(EstadoCivilDataTransfer estadoCivilDataTransfer)
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
                estadoCivilRetorno.ErroMensagens.Add("Erro em EstadoCivilController Inclusao [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivilRetorno.Erro || !estadoCivilRetorno.Validacao) {
                return BadRequest(estadoCivilRetorno);
            } else {
                string uri = Url.Action("Form", new { id = estadoCivilRetorno.EstadoCivil.Id });

                return Created(uri, estadoCivilRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alteracao(EstadoCivilDataTransfer estadoCivilDataTransfer)
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
                estadoCivilRetorno.ErroMensagens.Add("Erro em EstadoCivilController Alteracao [" + ex.Message + "]");
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
        public IActionResult Exclusao(int id)
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
                estadoCivilRetorno.ErroMensagens.Add("Erro em EstadoCivilController Exclusao [" + ex.Message + "]");
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
