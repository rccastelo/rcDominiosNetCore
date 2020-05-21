using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosDataTransfers;
using rcDominiosWeb.Models;

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
            } catch {
                usuarioTipoForm = new UsuarioTipoDataTransfer();
                
                usuarioTipoForm.Validacao = false;
                usuarioTipoForm.Erro = true;
                usuarioTipoForm.IncluirErroMensagem("Erro em UsuarioTipoController Form");
            } finally {
                usuarioTipoModel = null;
            }

            return View(usuarioTipoForm);
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
                usuarioTipoLista.IncluirErroMensagem("Erro em UsuarioTipoController Lista [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            return View(usuarioTipoLista);
        }

        [HttpPost]
        public IActionResult Consulta(UsuarioTipoDataTransfer usuarioTipoDataTransfer)
        {
            UsuarioTipoModel usuarioTipoModel;
            UsuarioTipoDataTransfer usuarioTipoLista;

            try {
                usuarioTipoModel = new UsuarioTipoModel();

                usuarioTipoLista = usuarioTipoModel.Consultar(usuarioTipoDataTransfer);
            } catch (Exception ex) {
                usuarioTipoLista = new UsuarioTipoDataTransfer();

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
                usuarioTipoRetorno.IncluirErroMensagem("Erro em UsuarioTipoController Inclusao [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipoRetorno.Erro || !usuarioTipoRetorno.Validacao) {
                return View("Form", usuarioTipoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
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
                usuarioTipoRetorno.IncluirErroMensagem("Erro em UsuarioTipoController Alteracao [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipoRetorno.Erro || !usuarioTipoRetorno.Validacao) {
                return View("Form", usuarioTipoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
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
                usuarioTipoRetorno.IncluirErroMensagem("Erro em UsuarioTipoController Exclusao [" + ex.Message + "]");
            } finally {
                usuarioTipoModel = null;
            }

            if (usuarioTipoRetorno.Erro || !usuarioTipoRetorno.Validacao) {
                return View("Form", usuarioTipoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
