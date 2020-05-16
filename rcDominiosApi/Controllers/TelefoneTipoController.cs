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
    public class TelefoneTipoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Form(int id)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoDataTransfer telefoneTipoForm;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                if (id > 0) {
                    telefoneTipoForm = telefoneTipoModel.ConsultarPorId(id);
                } else {
                    telefoneTipoForm = null;
                }
            } catch (Exception ex) {
                telefoneTipoForm = new TelefoneTipoDataTransfer();
                
                telefoneTipoForm.Validacao = false;
                telefoneTipoForm.Erro = true;
                telefoneTipoForm.ErroMensagens.Add("Erro em TelefoneTipoController Form [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            if (telefoneTipoForm.Erro || !telefoneTipoForm.Validacao) {
                return BadRequest(telefoneTipoForm);
            } else {
                return Ok(telefoneTipoForm);
            }
        }

        [HttpGet]
        public IActionResult Lista()
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoDataTransfer telefoneTipoLista;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipoLista = telefoneTipoModel.Listar();
            } catch (Exception ex) {
                telefoneTipoLista = new TelefoneTipoDataTransfer();

                telefoneTipoLista.Validacao = false;
                telefoneTipoLista.Erro = true;
                telefoneTipoLista.ErroMensagens.Add("Erro em TelefoneTipoController Lista [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            if (telefoneTipoLista.Erro || !telefoneTipoLista.Validacao) {
                return BadRequest(telefoneTipoLista);
            } else {
                return Ok(telefoneTipoLista);
            }
        }

        [HttpPost]
        public IActionResult Inclusao(TelefoneTipoDataTransfer telefoneTipoDataTransfer)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoDataTransfer telefoneTipoRetorno;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipoRetorno = telefoneTipoModel.Incluir(telefoneTipoDataTransfer);
            } catch (Exception ex) {
                telefoneTipoRetorno = new TelefoneTipoDataTransfer();

                telefoneTipoRetorno.Validacao = false;
                telefoneTipoRetorno.Erro = true;
                telefoneTipoRetorno.ErroMensagens.Add("Erro em TelefoneTipoController Inclusao [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            if (telefoneTipoRetorno.Erro || !telefoneTipoRetorno.Validacao) {
                return BadRequest(telefoneTipoRetorno);
            } else {
                string uri = Url.Action("Form", new { id = telefoneTipoRetorno.TelefoneTipo.Id });

                return Created(uri, telefoneTipoRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alteracao(TelefoneTipoDataTransfer telefoneTipoDataTransfer)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoDataTransfer telefoneTipoRetorno;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipoRetorno = telefoneTipoModel.Alterar(telefoneTipoDataTransfer);
            } catch (Exception ex) {
                telefoneTipoRetorno = new TelefoneTipoDataTransfer();

                telefoneTipoRetorno.Validacao = false;
                telefoneTipoRetorno.Erro = true;
                telefoneTipoRetorno.ErroMensagens.Add("Erro em TelefoneTipoController Alteracao [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            if (telefoneTipoRetorno.Erro || !telefoneTipoRetorno.Validacao) {
                return BadRequest(telefoneTipoRetorno);
            } else {
                return Ok(telefoneTipoRetorno);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Exclusao(int id)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoDataTransfer telefoneTipoRetorno;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipoRetorno = telefoneTipoModel.Excluir(id);
            } catch (Exception ex) {
                telefoneTipoRetorno = new TelefoneTipoDataTransfer();

                telefoneTipoRetorno.Validacao = false;
                telefoneTipoRetorno.Erro = true;
                telefoneTipoRetorno.ErroMensagens.Add("Erro em TelefoneTipoController Exclusao [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            if (telefoneTipoRetorno.Erro || !telefoneTipoRetorno.Validacao) {
                return BadRequest(telefoneTipoRetorno);
            } else {
                return NoContent();
            }
        }
    }
}
