using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcDominiosWeb.Models;
using rcDominiosTransfers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace rcDominiosWeb.Controllers
{
    [Authorize]
    public class UsuarioController : ControllerDominios
    {
        public UsuarioController(IHttpContextAccessor accessor)
            :base(accessor)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Usuario"] = UsuarioNome;

            return View();
        }

        [HttpGet]
        public IActionResult Filtro()
        {
            ViewData["Usuario"] = UsuarioNome;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuario;

            try {
                usuarioModel = new UsuarioModel(httpContext);

                if (id > 0) {
                    usuario = await usuarioModel.ConsultarPorId(id);
                } else {
                    usuario = null;
                }
            } catch {
                usuario = new UsuarioTransfer();
                
                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioController Form");
            } finally {
                usuarioModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuarioLista;

            try {
                usuarioModel = new UsuarioModel(httpContext);

                usuarioLista = await usuarioModel.Consultar(new UsuarioTransfer());
            } catch (Exception ex) {
                usuarioLista = new UsuarioTransfer();

                usuarioLista.Validacao = false;
                usuarioLista.Erro = true;
                usuarioLista.IncluirMensagem("Erro em UsuarioController Lista [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            return View(usuarioLista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consulta(UsuarioTransfer usuarioTransfer)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuarioLista;

            try {
                usuarioModel = new UsuarioModel(httpContext);

                usuarioLista = await usuarioModel.Consultar(usuarioTransfer);
            } catch (Exception ex) {
                usuarioLista = new UsuarioTransfer();

                usuarioLista.Validacao = false;
                usuarioLista.Erro = true;
                usuarioLista.IncluirMensagem("Erro em UsuarioController Consulta [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            if (usuarioLista.Erro || !usuarioLista.Validacao) {
                return View("Filtro", usuarioLista);
            } else {
                return View("Lista", usuarioLista);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inclusao(UsuarioTransfer usuarioTransfer)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuario;

            try {
                usuarioModel = new UsuarioModel(httpContext);

                usuario = await usuarioModel.Incluir(usuarioTransfer);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioController Inclusao [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            if (usuario.Erro || !usuario.Validacao) {
                return View("Form", usuario);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alteracao(UsuarioTransfer usuarioTransfer)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuario;

            try {
                usuarioModel = new UsuarioModel(httpContext);

                usuario = await usuarioModel.Alterar(usuarioTransfer);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioController Alteracao [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            if (usuario.Erro || !usuario.Validacao) {
                return View("Form", usuario);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuario;

            try {
                usuarioModel = new UsuarioModel(httpContext);

                usuario = await usuarioModel.Excluir(id);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioController Exclusao [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            if (usuario.Erro || !usuario.Validacao) {
                return View("Form", usuario);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
