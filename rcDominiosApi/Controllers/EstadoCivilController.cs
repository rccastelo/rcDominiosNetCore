using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosTransfers;

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

            if (estadoCivil.Erro || !estadoCivil.Validacao) {
                return BadRequest(estadoCivil);
            } else {
                return Ok(estadoCivil);
            }
        }

        [HttpGet]
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

            if (estadoCivilLista.Erro || !estadoCivilLista.Validacao) {
                return BadRequest(estadoCivilLista);
            } else {
                return Ok(estadoCivilLista);
            }
        }

        [HttpPost("lista")]
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

            if (estadoCivilLista.Erro || !estadoCivilLista.Validacao) {
                return BadRequest(estadoCivilLista);
            } else {
                return Ok(estadoCivilLista);
            }
        }

        [HttpPost]
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

            if (estadoCivil.Erro || !estadoCivil.Validacao) {
                return BadRequest(estadoCivil);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = estadoCivil.EstadoCivil.Id });

                return Created(uri, estadoCivil);
            }
        }

        [HttpPut]
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

            if (estadoCivil.Erro || !estadoCivil.Validacao) {
                return BadRequest(estadoCivil);
            } else {
                return Ok(estadoCivil);
            }
        }

        [HttpDelete("{id}")]
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

            if (estadoCivil.Erro || !estadoCivil.Validacao) {
                return BadRequest(estadoCivil);
            } else {
                return Ok(estadoCivil);
            }
        }
    }
}
