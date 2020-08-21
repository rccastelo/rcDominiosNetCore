using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosTransfers;
using Swashbuckle.AspNetCore.Annotations;

namespace rcDominiosApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Consultar Usuário pelo Id",
            Description = "[pt-BR] Consultar Usuário pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Consult User by Id. Authentication token is required.",
            Tags = new[] { "Usuario" }
        )]
        [ProducesResponseType(typeof(UsuarioTransfer), 200)]
        [ProducesResponseType(typeof(UsuarioTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
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

            usuario.TratarLinks();

            if (usuario.Erro || !usuario.Validacao) {
                return BadRequest(usuario);
            } else {
                return Ok(usuario);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar Usuário",
            Description = "[pt-BR] Listar Usuário. Requer token de autenticação. \n\n " +
                "[en-US] List User. Authentication token is required.",
            Tags = new[] { "Usuario" }
        )]
        [ProducesResponseType(typeof(UsuarioTransfer), 200)]
        [ProducesResponseType(typeof(UsuarioTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
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

            usuarioLista.TratarLinks();

            if (usuarioLista.Erro || !usuarioLista.Validacao) {
                return BadRequest(usuarioLista);
            } else {
                return Ok(usuarioLista);
            }
        }

        [HttpPost("lista")]
        [SwaggerOperation(
            Summary = "Filtrar Usuário",
            Description = "[pt-BR] Filtrar Usuário. Requer token de autenticação. \n\n " +
                "[en-US] Filter User. Authentication token is required.",
            Tags = new[] { "Usuario" }
        )]
        [ProducesResponseType(typeof(UsuarioTransfer), 200)]
        [ProducesResponseType(typeof(UsuarioTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
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

            usuarioLista.TratarLinks();

            if (usuarioLista.Erro || !usuarioLista.Validacao) {
                return BadRequest(usuarioLista);
            } else {
                return Ok(usuarioLista);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Incluir Usuário",
            Description = "[pt-BR] Incluir Usuário. Requer token de autenticação. \n\n " +
                "[en-US] Add User. Authentication token is required.",
            Tags = new[] { "Usuario" }
        )]
        [ProducesResponseType(typeof(UsuarioTransfer), 201)]
        [ProducesResponseType(typeof(UsuarioTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
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

            usuario.TratarLinks();

            if (usuario.Erro || !usuario.Validacao) {
                return BadRequest(usuario);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = usuario.Usuario.Id });

                return Created(uri, usuario);
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Alterar Usuário",
            Description = "[pt-BR] Alterar Usuário. Requer token de autenticação. \n\n " +
                "[en-US] Update User. Authentication token is required.",
            Tags = new[] { "Usuario" }
        )]
        [ProducesResponseType(typeof(UsuarioTransfer), 200)]
        [ProducesResponseType(typeof(UsuarioTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
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

            usuario.TratarLinks();

            if (usuario.Erro || !usuario.Validacao) {
                return BadRequest(usuario);
            } else {
                return Ok(usuario);
            }
        }

        [HttpPut("senha")]
        [SwaggerOperation(
            Summary = "Alterar Senha de Usuário",
            Description = "[pt-BR] Alterar Senha de Usuário. Requer token de autenticação. \n\n " +
                "[en-US] Update User Password. Authentication token is required.",
            Tags = new[] { "Usuario" }
        )]
        [ProducesResponseType(typeof(UsuarioTransfer), 200)]
        [ProducesResponseType(typeof(UsuarioTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult AlterarSenha(UsuarioTransfer usuarioTransfer)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuario;

            try {
                usuarioModel = new UsuarioModel();

                usuario = usuarioModel.AlterarSenha(usuarioTransfer);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioController AlterarSenha [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            usuario.TratarLinks();

            if (usuario.Erro || !usuario.Validacao) {
                return BadRequest(usuario);
            } else {
                return Ok(usuario);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir Usuário pelo Id",
            Description = "[pt-BR] Excluir Usuário pelo Id. Requer token de autenticação. \n\n " +
                "[en-US] Delete User by Id. Authentication token is required.",
            Tags = new[] { "Usuario" }
        )]
        [ProducesResponseType(typeof(UsuarioTransfer), 200)]
        [ProducesResponseType(typeof(UsuarioTransfer), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
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

            usuario.TratarLinks();

            if (usuario.Erro || !usuario.Validacao) {
                return BadRequest(usuario);
            } else {
                return Ok(usuario);
            }
        }
    }
}
