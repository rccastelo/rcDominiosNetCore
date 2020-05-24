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
    public class EnderecoTipoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoTransfer enderecoTipo;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                if (id > 0) {
                    enderecoTipo = enderecoTipoModel.ConsultarPorId(id);
                } else {
                    enderecoTipo = null;
                }
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();
                
                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoController ConsultarPorId [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipo.Erro || !enderecoTipo.Validacao) {
                return BadRequest(enderecoTipo);
            } else {
                return Ok(enderecoTipo);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoTransfer enderecoTipoLista;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipoLista = enderecoTipoModel.Consultar(new EnderecoTipoTransfer());
            } catch (Exception ex) {
                enderecoTipoLista = new EnderecoTipoTransfer();

                enderecoTipoLista.Validacao = false;
                enderecoTipoLista.Erro = true;
                enderecoTipoLista.IncluirErroMensagem("Erro em EnderecoTipoController Listar [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipoLista.Erro || !enderecoTipoLista.Validacao) {
                return BadRequest(enderecoTipoLista);
            } else {
                return Ok(enderecoTipoLista);
            }
        }

        [HttpPost("lista")]
        public IActionResult Consultar(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoTransfer enderecoTipoLista;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipoLista = enderecoTipoModel.Consultar(enderecoTipoTransfer);
            } catch (Exception ex) {
                enderecoTipoLista = new EnderecoTipoTransfer();

                enderecoTipoLista.Validacao = false;
                enderecoTipoLista.Erro = true;
                enderecoTipoLista.IncluirErroMensagem("Erro em EnderecoTipoController Consultar [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipoLista.Erro || !enderecoTipoLista.Validacao) {
                return BadRequest(enderecoTipoLista);
            } else {
                return Ok(enderecoTipoLista);
            }
        }

        [HttpPost]
        public IActionResult Incluir(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoTransfer enderecoTipo;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipo = enderecoTipoModel.Incluir(enderecoTipoTransfer);
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoController Incluir [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipo.Erro || !enderecoTipo.Validacao) {
                return BadRequest(enderecoTipo);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = enderecoTipo.EnderecoTipo.Id });

                return Created(uri, enderecoTipo);
            }
        }

        [HttpPut]
        public IActionResult Alterar(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoTransfer enderecoTipo;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipo = enderecoTipoModel.Alterar(enderecoTipoTransfer);
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoController Alterar [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipo.Erro || !enderecoTipo.Validacao) {
                return BadRequest(enderecoTipo);
            } else {
                return Ok(enderecoTipo);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoTransfer enderecoTipo;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipo = enderecoTipoModel.Excluir(id);
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoController Excluir [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipo.Erro || !enderecoTipo.Validacao) {
                return BadRequest(enderecoTipo);
            } else {
                return Ok(enderecoTipo);
            }
        }
    }
}
