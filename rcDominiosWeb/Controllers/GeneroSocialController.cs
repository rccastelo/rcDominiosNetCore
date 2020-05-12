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
            GeneroSocialModel generoSocialModel;
            GeneroSocialDataTransfer generoSocialForm;

            try {
                generoSocialModel = new GeneroSocialModel();

                if (id > 0) {
                    generoSocialForm = generoSocialModel.ConsultarPorId(id);
                } else {
                    generoSocialForm = null;
                }
            } catch {
                generoSocialForm = new GeneroSocialDataTransfer();
                
                generoSocialForm.Validacao = false;
                generoSocialForm.Erro = true;
                generoSocialForm.ErroMensagens.Add("Erro em GeneroSocialController Form");
            } finally {
                generoSocialModel = null;
            }

            return View(generoSocialForm);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialDataTransfer generoSocialLista;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialLista = generoSocialModel.Listar();
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialDataTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.ErroMensagens.Add("Erro em GeneroSocialController Lista [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            return View(generoSocialLista);
        }

        [HttpPost]
        public IActionResult Consulta(GeneroSocialDataTransfer generoSocialDataTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialDataTransfer generoSocialLista;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialLista = generoSocialModel.Consultar(generoSocialDataTransfer);
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialDataTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.ErroMensagens.Add("Erro em GeneroSocialController Consulta [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocialLista.Erro || !generoSocialLista.Validacao) {
                return View("Filtro", generoSocialLista);
            } else {
                return View("Lista", generoSocialLista);
            }
        }

        [HttpPost]
        public IActionResult Inclusao(GeneroSocialDataTransfer generoSocialDataTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialDataTransfer generoSocialRetorno;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialRetorno = generoSocialModel.Incluir(generoSocialDataTransfer);
            } catch (Exception ex) {
                generoSocialRetorno = new GeneroSocialDataTransfer();

                generoSocialRetorno.Validacao = false;
                generoSocialRetorno.Erro = true;
                generoSocialRetorno.ErroMensagens.Add("Erro em GeneroSocialController Inclusao [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocialRetorno.Erro || !generoSocialRetorno.Validacao) {
                return View("Form", generoSocialRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public IActionResult Alteracao(GeneroSocialDataTransfer generoSocialDataTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialDataTransfer generoSocialRetorno;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialRetorno = generoSocialModel.Alterar(generoSocialDataTransfer);
            } catch (Exception ex) {
                generoSocialRetorno = new GeneroSocialDataTransfer();

                generoSocialRetorno.Validacao = false;
                generoSocialRetorno.Erro = true;
                generoSocialRetorno.ErroMensagens.Add("Erro em GeneroSocialController Alteracao [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocialRetorno.Erro || !generoSocialRetorno.Validacao) {
                return View("Form", generoSocialRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public IActionResult Exclusao(int id)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialDataTransfer generoSocialRetorno;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialRetorno = generoSocialModel.Excluir(id);
            } catch (Exception ex) {
                generoSocialRetorno = new GeneroSocialDataTransfer();

                generoSocialRetorno.Validacao = false;
                generoSocialRetorno.Erro = true;
                generoSocialRetorno.ErroMensagens.Add("Erro em GeneroSocialController Exclusao [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocialRetorno.Erro || !generoSocialRetorno.Validacao) {
                return View("Form", generoSocialRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
