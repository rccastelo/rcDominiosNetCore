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
    public class EnderecoTipoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoDataTransfer enderecoTipoForm;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                if (id > 0) {
                    enderecoTipoForm = enderecoTipoModel.ConsultarPorId(id);
                } else {
                    enderecoTipoForm = null;
                }
            } catch (Exception ex) {
                enderecoTipoForm = new EnderecoTipoDataTransfer();
                
                enderecoTipoForm.Validacao = false;
                enderecoTipoForm.Erro = true;
                enderecoTipoForm.IncluirErroMensagem("Erro em EnderecoTipoController ConsultarPorId [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipoForm.Erro || !enderecoTipoForm.Validacao) {
                return BadRequest(enderecoTipoForm);
            } else {
                return Ok(enderecoTipoForm);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoDataTransfer enderecoTipoLista;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipoLista = enderecoTipoModel.Listar();
            } catch (Exception ex) {
                enderecoTipoLista = new EnderecoTipoDataTransfer();

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

        [HttpPost]
        public IActionResult Incluir(EnderecoTipoDataTransfer enderecoTipoDataTransfer)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoDataTransfer enderecoTipoRetorno;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipoRetorno = enderecoTipoModel.Incluir(enderecoTipoDataTransfer);
            } catch (Exception ex) {
                enderecoTipoRetorno = new EnderecoTipoDataTransfer();

                enderecoTipoRetorno.Validacao = false;
                enderecoTipoRetorno.Erro = true;
                enderecoTipoRetorno.IncluirErroMensagem("Erro em EnderecoTipoController Incluir [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipoRetorno.Erro || !enderecoTipoRetorno.Validacao) {
                return BadRequest(enderecoTipoRetorno);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = enderecoTipoRetorno.EnderecoTipo.Id });

                return Created(uri, enderecoTipoRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alterar(EnderecoTipoDataTransfer enderecoTipoDataTransfer)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoDataTransfer enderecoTipoRetorno;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipoRetorno = enderecoTipoModel.Alterar(enderecoTipoDataTransfer);
            } catch (Exception ex) {
                enderecoTipoRetorno = new EnderecoTipoDataTransfer();

                enderecoTipoRetorno.Validacao = false;
                enderecoTipoRetorno.Erro = true;
                enderecoTipoRetorno.IncluirErroMensagem("Erro em EnderecoTipoController Alterar [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipoRetorno.Erro || !enderecoTipoRetorno.Validacao) {
                return BadRequest(enderecoTipoRetorno);
            } else {
                return Ok(enderecoTipoRetorno);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoDataTransfer enderecoTipoRetorno;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipoRetorno = enderecoTipoModel.Excluir(id);
            } catch (Exception ex) {
                enderecoTipoRetorno = new EnderecoTipoDataTransfer();

                enderecoTipoRetorno.Validacao = false;
                enderecoTipoRetorno.Erro = true;
                enderecoTipoRetorno.IncluirErroMensagem("Erro em EnderecoTipoController Excluir [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipoRetorno.Erro || !enderecoTipoRetorno.Validacao) {
                return BadRequest(enderecoTipoRetorno);
            } else {
                return NoContent();
            }
        }
    }
}
