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
    public class UsuarioTipoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoTransfer usuarioTipo;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                if (id > 0) {
                    usuarioTipo = usuarioTipoModel.ConsultarPorId(id);
                } else {
                    usuarioTipo = null;
                }
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();
                
                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoController ConsultarPorId [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipo.Erro || !usuarioTipo.Validacao) {
                return BadRequest(usuarioTipo);
            } else {
                return Ok(usuarioTipo);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoTransfer usuarioTipoLista;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipoLista = usuarioTipoModel.Consultar(new UsuarioTipoTransfer());
            } catch (Exception ex) {
                usuarioTipoLista = new UsuarioTipoTransfer();

                usuarioTipoLista.Validacao = false;
                usuarioTipoLista.Erro = true;
                usuarioTipoLista.IncluirMensagem("Erro em UsuarioTipoController Listar [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipoLista.Erro || !usuarioTipoLista.Validacao) {
                return BadRequest(usuarioTipoLista);
            } else {
                return Ok(usuarioTipoLista);
            }
        }

        [HttpPost("lista")]
        public IActionResult Consultar(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoTransfer usuarioTipoLista;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipoLista = usuarioTipoModel.Consultar(usuarioTipoTransfer);
            } catch (Exception ex) {
                usuarioTipoLista = new UsuarioTipoTransfer();

                usuarioTipoLista.Validacao = false;
                usuarioTipoLista.Erro = true;
                usuarioTipoLista.IncluirMensagem("Erro em UsuarioTipoController Consultar [" + ex.Message + "]");
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
        public IActionResult Incluir(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoTransfer usuarioTipo;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipo = usuarioTipoModel.Incluir(usuarioTipoTransfer);
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoController Incluir [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipo.Erro || !usuarioTipo.Validacao) {
                return BadRequest(usuarioTipo);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = usuarioTipo.UsuarioTipo.Id });

                return Created(uri, usuarioTipo);
            }
        }

        [HttpPut]
        public IActionResult Alterar(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoTransfer usuarioTipo;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipo = usuarioTipoModel.Alterar(usuarioTipoTransfer);
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoController Alterar [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipo.Erro || !usuarioTipo.Validacao) {
                return BadRequest(usuarioTipo);
            } else {
                return Ok(usuarioTipo);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoTransfer usuarioTipo;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipo = usuarioTipoModel.Excluir(id);
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoController Excluir [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipo.Erro || !usuarioTipo.Validacao) {
                return BadRequest(usuarioTipo);
            } else {
                return Ok(usuarioTipo);
            }
        }
    }
}
