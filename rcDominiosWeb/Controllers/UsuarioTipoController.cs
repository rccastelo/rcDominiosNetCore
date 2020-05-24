using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcDominiosWeb.Models;
using rcDominiosTransfers;

namespace rcDominiosWeb.Controllers
{
  public class UsuarioTipoController : Controller
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
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoTransfer usuarioTipo;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                if (id > 0) {
                    usuarioTipo = await usuarioTipoModel.ConsultarPorId(id);
                } else {
                    usuarioTipo = null;
                }
            } catch {
                usuarioTipo = new UsuarioTipoTransfer();
                
                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirErroMensagem("Erro em UsuarioTipoController Form");
            } finally {
                usuarioTipoModel = null;
            }

            return View(usuarioTipo);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoTransfer usuarioTipoLista;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipoLista = await usuarioTipoModel.Consultar(new UsuarioTipoTransfer());
            } catch (Exception ex) {
                usuarioTipoLista = new UsuarioTipoTransfer();

                usuarioTipoLista.Validacao = false;
                usuarioTipoLista.Erro = true;
                usuarioTipoLista.IncluirErroMensagem("Erro em UsuarioTipoController Lista [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            return View(usuarioTipoLista);
        }

        [HttpPost]
        public async Task<IActionResult> Consulta(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoTransfer usuarioTipoLista;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipoLista = await usuarioTipoModel.Consultar(usuarioTipoTransfer);
            } catch (Exception ex) {
                usuarioTipoLista = new UsuarioTipoTransfer();

                usuarioTipoLista.Validacao = false;
                usuarioTipoLista.Erro = true;
                usuarioTipoLista.IncluirErroMensagem("Erro em UsuarioTipoController Consulta [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipoLista.Erro || !usuarioTipoLista.Validacao) {
                return View("Filtro", usuarioTipoLista);
            } else {
                return View("Lista", usuarioTipoLista);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Inclusao(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoTransfer usuarioTipo;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipo = await usuarioTipoModel.Incluir(usuarioTipoTransfer);
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirErroMensagem("Erro em UsuarioTipoController Inclusao [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipo.Erro || !usuarioTipo.Validacao) {
                return View("Form", usuarioTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Alteracao(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoTransfer usuarioTipo;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipo = await usuarioTipoModel.Alterar(usuarioTipoTransfer);
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirErroMensagem("Erro em UsuarioTipoController Alteracao [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipo.Erro || !usuarioTipo.Validacao) {
                return View("Form", usuarioTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoTransfer usuarioTipo;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipo = await usuarioTipoModel.Excluir(id);
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirErroMensagem("Erro em UsuarioTipoController Exclusao [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipo.Erro || !usuarioTipo.Validacao) {
                return View("Form", usuarioTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
