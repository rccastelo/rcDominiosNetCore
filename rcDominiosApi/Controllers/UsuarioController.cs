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
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuario;

            try {
                usuarioModel = new UsuarioModel();

                if (id > 0) {
                    usuario = usuarioModel.ConsultarPorId(id);
                } else {
                    usuario = null;
                }
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();
                
                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioController ConsultarPorId [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            if (usuario.Erro || !usuario.Validacao) {
                return BadRequest(usuario);
            } else {
                return Ok(usuario);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuarioLista;

            try {
                usuarioModel = new UsuarioModel();

                usuarioLista = usuarioModel.Consultar(new UsuarioTransfer());
            } catch (Exception ex) {
                usuarioLista = new UsuarioTransfer();

                usuarioLista.Erro = true;
                usuarioLista.IncluirMensagem("Erro em UsuarioController Listar [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            if (usuarioLista.Erro || !usuarioLista.Validacao) {
                return BadRequest(usuarioLista);
            } else {
                return Ok(usuarioLista);
            }
        }

        [HttpPost("lista")]
        public IActionResult Consultar(UsuarioTransfer usuarioTransfer)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuarioLista;

            try {
                usuarioModel = new UsuarioModel();

                usuarioLista = usuarioModel.Consultar(usuarioTransfer);
            } catch (Exception ex) {
                usuarioLista = new UsuarioTransfer();

                usuarioLista.Erro = true;
                usuarioLista.IncluirMensagem("Erro em UsuarioController Consultar [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            if (usuarioLista.Erro || !usuarioLista.Validacao) {
                return BadRequest(usuarioLista);
            } else {
                return Ok(usuarioLista);
            }
        }

        [HttpPost]
        public IActionResult Incluir(UsuarioTransfer usuarioTransfer)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuario;

            try {
                usuarioModel = new UsuarioModel();

                usuario = usuarioModel.Incluir(usuarioTransfer);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioController Incluir [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            if (usuario.Erro || !usuario.Validacao) {
                return BadRequest(usuario);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = usuario.Usuario.Id });

                return Created(uri, usuario);
            }
        }

        [HttpPut]
        public IActionResult Alterar(UsuarioTransfer usuarioTransfer)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuario;

            try {
                usuarioModel = new UsuarioModel();

                usuario = usuarioModel.Alterar(usuarioTransfer);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioController Alterar [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            if (usuario.Erro || !usuario.Validacao) {
                return BadRequest(usuario);
            } else {
                return Ok(usuario);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuario;

            try {
                usuarioModel = new UsuarioModel();

                usuario = usuarioModel.Excluir(id);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioController Excluir [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            if (usuario.Erro || !usuario.Validacao) {
                return BadRequest(usuario);
            } else {
                return Ok(usuario);
            }
        }
    }
}
