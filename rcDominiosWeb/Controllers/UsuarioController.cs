using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcDominiosWeb.Models;
using rcDominiosTransfers;

namespace rcDominiosWeb.Controllers
{
  public class UsuarioController : Controller
    {
        [HttpGet, HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Filtro()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuario;

            try {
                usuarioModel = new UsuarioModel();

                if (id > 0) {
                    usuario = await usuarioModel.ConsultarPorId(id);
                } else {
                    usuario = null;
                }
            } catch {
                usuario = new UsuarioTransfer();
                
                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioController Form");
            } finally {
                usuarioModel = null;
            }

            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuarioLista;

            try {
                usuarioModel = new UsuarioModel();

                usuarioLista = await usuarioModel.Consultar(new UsuarioTransfer());
            } catch (Exception ex) {
                usuarioLista = new UsuarioTransfer();

                usuarioLista.Validacao = false;
                usuarioLista.Erro = true;
                usuarioLista.IncluirErroMensagem("Erro em UsuarioController Lista [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            return View(usuarioLista);
        }

        [HttpPost]
        public async Task<IActionResult> Consulta(UsuarioTransfer usuarioTransfer)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuarioLista;

            try {
                usuarioModel = new UsuarioModel();

                usuarioLista = await usuarioModel.Consultar(usuarioTransfer);
            } catch (Exception ex) {
                usuarioLista = new UsuarioTransfer();

                usuarioLista.Validacao = false;
                usuarioLista.Erro = true;
                usuarioLista.IncluirErroMensagem("Erro em UsuarioController Consulta [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            if (usuarioLista.Erro || !usuarioLista.Validacao) {
                return View("Filtro", usuarioLista);
            } else {
                return View("Lista", usuarioLista);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Inclusao(UsuarioTransfer usuarioTransfer)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuario;

            try {
                usuarioModel = new UsuarioModel();

                usuario = await usuarioModel.Incluir(usuarioTransfer);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioController Inclusao [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            if (usuario.Erro || !usuario.Validacao) {
                return View("Form", usuario);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Alteracao(UsuarioTransfer usuarioTransfer)
        {
            UsuarioModel usuarioModel;
            UsuarioTransfer usuario;

            try {
                usuarioModel = new UsuarioModel();

                usuario = await usuarioModel.Alterar(usuarioTransfer);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioController Alteracao [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

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
                usuarioModel = new UsuarioModel();

                usuario = await usuarioModel.Excluir(id);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioController Exclusao [" + ex.Message + "]");
            } finally {
                usuarioModel = null;
            }

            if (usuario.Erro || !usuario.Validacao) {
                return View("Form", usuario);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
