using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcDominiosWeb.Models;
using rcDominiosTransfers;

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
        public async Task<IActionResult> Form(int id)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel();

                if (id > 0) {
                    generoSocial = await generoSocialModel.ConsultarPorId(id);
                } else {
                    generoSocial = null;
                }
            } catch {
                generoSocial = new GeneroSocialTransfer();
                
                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialController Form");
            } finally {
                generoSocialModel = null;
            }

            return View(generoSocial);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocialLista;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialLista = await generoSocialModel.Consultar(new GeneroSocialTransfer());
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.IncluirErroMensagem("Erro em GeneroSocialController Lista [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            return View(generoSocialLista);
        }

        [HttpPost]
        public async Task<IActionResult> Consulta(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocialLista;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialLista = await generoSocialModel.Consultar(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.IncluirErroMensagem("Erro em GeneroSocialController Consulta [" + ex.Message + "]");
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
        public async Task<IActionResult> Inclusao(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocial = await generoSocialModel.Incluir(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialController Inclusao [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocial.Erro || !generoSocial.Validacao) {
                return View("Form", generoSocial);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Alteracao(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocial = await generoSocialModel.Alterar(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialController Alteracao [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocial.Erro || !generoSocial.Validacao) {
                return View("Form", generoSocial);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocial = await generoSocialModel.Excluir(id);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialController Exclusao [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocial.Erro || !generoSocial.Validacao) {
                return View("Form", generoSocial);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
