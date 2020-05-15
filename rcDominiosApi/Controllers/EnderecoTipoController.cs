using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosDataTransfers;

namespace rcDominiosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoTipoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Form(int id)
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
                enderecoTipoForm.ErroMensagens.Add("Erro em EnderecoTipoController Form [" + ex.Message + "]");
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
        public IActionResult Lista()
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
                enderecoTipoLista.ErroMensagens.Add("Erro em EnderecoTipoController Lista [" + ex.Message + "]");
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
        public IActionResult Inclusao(EnderecoTipoDataTransfer enderecoTipoDataTransfer)
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
                enderecoTipoRetorno.ErroMensagens.Add("Erro em EnderecoTipoController Inclusao [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipoRetorno.Erro || !enderecoTipoRetorno.Validacao) {
                return BadRequest(enderecoTipoRetorno);
            } else {
                string uri = Url.Action("Form", new { id = enderecoTipoRetorno.EnderecoTipo.Id });

                return Created(uri, enderecoTipoRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alteracao(EnderecoTipoDataTransfer enderecoTipoDataTransfer)
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
                enderecoTipoRetorno.ErroMensagens.Add("Erro em EnderecoTipoController Alteracao [" + ex.Message + "]");
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
        public IActionResult Exclusao(int id)
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
                enderecoTipoRetorno.ErroMensagens.Add("Erro em EnderecoTipoController Exclusao [" + ex.Message + "]");
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
