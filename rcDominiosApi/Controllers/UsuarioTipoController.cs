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
    public class UsuarioTipoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Form(int id)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoDataTransfer usuarioTipoForm;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                if (id > 0) {
                    usuarioTipoForm = usuarioTipoModel.ConsultarPorId(id);
                } else {
                    usuarioTipoForm = null;
                }
            } catch (Exception ex) {
                usuarioTipoForm = new UsuarioTipoDataTransfer();
                
                usuarioTipoForm.Validacao = false;
                usuarioTipoForm.Erro = true;
                usuarioTipoForm.ErroMensagens.Add("Erro em UsuarioTipoController Form [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipoForm.Erro || !usuarioTipoForm.Validacao) {
                return BadRequest(usuarioTipoForm);
            } else {
                return Ok(usuarioTipoForm);
            }
        }

        [HttpGet]
        public IActionResult Lista()
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoDataTransfer usuarioTipoLista;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipoLista = usuarioTipoModel.Listar();
            } catch (Exception ex) {
                usuarioTipoLista = new UsuarioTipoDataTransfer();

                usuarioTipoLista.Validacao = false;
                usuarioTipoLista.Erro = true;
                usuarioTipoLista.ErroMensagens.Add("Erro em UsuarioTipoController Lista [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipoLista.Erro || !usuarioTipoLista.Validacao) {
                return BadRequest(usuarioTipoLista);
            } else {
                return Ok(usuarioTipoLista);
            }
        }

        [HttpPost]
        public IActionResult Inclusao(UsuarioTipoDataTransfer usuarioTipoDataTransfer)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoDataTransfer usuarioTipoRetorno;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipoRetorno = usuarioTipoModel.Incluir(usuarioTipoDataTransfer);
            } catch (Exception ex) {
                usuarioTipoRetorno = new UsuarioTipoDataTransfer();

                usuarioTipoRetorno.Validacao = false;
                usuarioTipoRetorno.Erro = true;
                usuarioTipoRetorno.ErroMensagens.Add("Erro em UsuarioTipoController Inclusao [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipoRetorno.Erro || !usuarioTipoRetorno.Validacao) {
                return BadRequest(usuarioTipoRetorno);
            } else {
                string uri = Url.Action("Form", new { id = usuarioTipoRetorno.UsuarioTipo.Id });

                return Created(uri, usuarioTipoRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alteracao(UsuarioTipoDataTransfer usuarioTipoDataTransfer)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoDataTransfer usuarioTipoRetorno;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipoRetorno = usuarioTipoModel.Alterar(usuarioTipoDataTransfer);
            } catch (Exception ex) {
                usuarioTipoRetorno = new UsuarioTipoDataTransfer();

                usuarioTipoRetorno.Validacao = false;
                usuarioTipoRetorno.Erro = true;
                usuarioTipoRetorno.ErroMensagens.Add("Erro em UsuarioTipoController Alteracao [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipoRetorno.Erro || !usuarioTipoRetorno.Validacao) {
                return BadRequest(usuarioTipoRetorno);
            } else {
                return Ok(usuarioTipoRetorno);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Exclusao(int id)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoDataTransfer usuarioTipoRetorno;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipoRetorno = usuarioTipoModel.Excluir(id);
            } catch (Exception ex) {
                usuarioTipoRetorno = new UsuarioTipoDataTransfer();

                usuarioTipoRetorno.Validacao = false;
                usuarioTipoRetorno.Erro = true;
                usuarioTipoRetorno.ErroMensagens.Add("Erro em UsuarioTipoController Exclusao [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipoRetorno.Erro || !usuarioTipoRetorno.Validacao) {
                return BadRequest(usuarioTipoRetorno);
            } else {
                return NoContent();
            }
        }
    }
}
