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
        public IActionResult ConsultarPorId(int id)
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
                usuarioTipoForm.IncluirErroMensagem("Erro em UsuarioTipoController ConsultarPorId [" + ex.Message + "]");
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
        public IActionResult Listar()
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
                usuarioTipoLista.IncluirErroMensagem("Erro em UsuarioTipoController Listar [" + ex.Message + "]");
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
        public IActionResult Incluir(UsuarioTipoDataTransfer usuarioTipoDataTransfer)
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
                usuarioTipoRetorno.IncluirErroMensagem("Erro em UsuarioTipoController Incluir [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipoRetorno.Erro || !usuarioTipoRetorno.Validacao) {
                return BadRequest(usuarioTipoRetorno);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = usuarioTipoRetorno.UsuarioTipo.Id });

                return Created(uri, usuarioTipoRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alterar(UsuarioTipoDataTransfer usuarioTipoDataTransfer)
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
                usuarioTipoRetorno.IncluirErroMensagem("Erro em UsuarioTipoController Alterar [" + ex.Message + "]");
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
        public IActionResult Excluir(int id)
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
                usuarioTipoRetorno.IncluirErroMensagem("Erro em UsuarioTipoController Excluir [" + ex.Message + "]");
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
