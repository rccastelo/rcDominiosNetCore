using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosDataTransfers;
using rcDominiosWeb.Models;

namespace rcDominiosWeb.Controllers
{
    public class GeneroSocialController : Controller
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
            GeneroSocialModel profissaoModel;
            GeneroSocialDataTransfer profissaoForm;

            try {
                profissaoModel = new GeneroSocialModel();

                if (id > 0) {
                    profissaoForm = profissaoModel.ConsultarPorId(id);
                } else {
                    profissaoForm = null;
                }
            } catch {
                profissaoForm = new GeneroSocialDataTransfer();
                
                profissaoForm.Validacao = false;
                profissaoForm.Erro = true;
                profissaoForm.ErroMensagens.Add("Erro em GeneroSocialController Form");
            } finally {
                profissaoModel = null;
            }

            return View(profissaoForm);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            GeneroSocialModel profissaoModel;
            GeneroSocialDataTransfer profissaoLista;

            try {
                profissaoModel = new GeneroSocialModel();

                profissaoLista = profissaoModel.Listar();
            } catch (Exception ex) {
                profissaoLista = new GeneroSocialDataTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.ErroMensagens.Add("Erro em GeneroSocialController Lista [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            return View(profissaoLista);
        }

        [HttpPost]
        public IActionResult Consulta(GeneroSocialDataTransfer profissaoDataTransfer)
        {
            GeneroSocialModel profissaoModel;
            GeneroSocialDataTransfer profissaoLista;

            try {
                profissaoModel = new GeneroSocialModel();

                profissaoLista = profissaoModel.Consultar(profissaoDataTransfer);
            } catch (Exception ex) {
                profissaoLista = new GeneroSocialDataTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.ErroMensagens.Add("Erro em GeneroSocialController Consulta [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoLista.Erro || !profissaoLista.Validacao) {
                return View("Filtro", profissaoLista);
            } else {
                return View("Lista", profissaoLista);
            }
        }

        [HttpPost]
        public IActionResult Inclusao(GeneroSocialDataTransfer profissaoDataTransfer)
        {
            GeneroSocialModel profissaoModel;
            GeneroSocialDataTransfer profissaoRetorno;

            try {
                profissaoModel = new GeneroSocialModel();

                profissaoRetorno = profissaoModel.Incluir(profissaoDataTransfer);
            } catch (Exception ex) {
                profissaoRetorno = new GeneroSocialDataTransfer();

                profissaoRetorno.Validacao = false;
                profissaoRetorno.Erro = true;
                profissaoRetorno.ErroMensagens.Add("Erro em GeneroSocialController Inclusao [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoRetorno.Erro || !profissaoRetorno.Validacao) {
                return View("Form", profissaoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public IActionResult Alteracao(GeneroSocialDataTransfer profissaoDataTransfer)
        {
            GeneroSocialModel profissaoModel;
            GeneroSocialDataTransfer profissaoRetorno;

            try {
                profissaoModel = new GeneroSocialModel();

                profissaoRetorno = profissaoModel.Alterar(profissaoDataTransfer);
            } catch (Exception ex) {
                profissaoRetorno = new GeneroSocialDataTransfer();

                profissaoRetorno.Validacao = false;
                profissaoRetorno.Erro = true;
                profissaoRetorno.ErroMensagens.Add("Erro em GeneroSocialController Alteracao [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoRetorno.Erro || !profissaoRetorno.Validacao) {
                return View("Form", profissaoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public IActionResult Exclusao(int id)
        {
            GeneroSocialModel profissaoModel;
            GeneroSocialDataTransfer profissaoRetorno;

            try {
                profissaoModel = new GeneroSocialModel();

                profissaoRetorno = profissaoModel.Excluir(id);
            } catch (Exception ex) {
                profissaoRetorno = new GeneroSocialDataTransfer();

                profissaoRetorno.Validacao = false;
                profissaoRetorno.Erro = true;
                profissaoRetorno.ErroMensagens.Add("Erro em GeneroSocialController Exclusao [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoRetorno.Erro || !profissaoRetorno.Validacao) {
                return View("Form", profissaoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
