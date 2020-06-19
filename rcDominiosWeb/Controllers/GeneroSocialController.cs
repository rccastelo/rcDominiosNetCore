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
    public class GeneroSocialController : ControllerDominios
    {
        public GeneroSocialController(IHttpContextAccessor accessor)
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
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel(httpContext);

                if (id > 0) {
                    generoSocial = await generoSocialModel.ConsultarPorId(id);
                } else {
                    generoSocial = null;
                }
            } catch {
                generoSocial = new GeneroSocialTransfer();
                
                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialController Form");
            } finally {
                generoSocialModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            return View(generoSocial);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocialLista;

            try {
                generoSocialModel = new GeneroSocialModel(httpContext);

                generoSocialLista = await generoSocialModel.Consultar(new GeneroSocialTransfer());
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.IncluirMensagem("Erro em GeneroSocialController Lista [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            return View(generoSocialLista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consulta(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocialLista;

            try {
                generoSocialModel = new GeneroSocialModel(httpContext);

                generoSocialLista = await generoSocialModel.Consultar(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.IncluirMensagem("Erro em GeneroSocialController Consulta [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            if (generoSocialLista.Erro || !generoSocialLista.Validacao) {
                return View("Filtro", generoSocialLista);
            } else {
                return View("Lista", generoSocialLista);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inclusao(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel(httpContext);

                generoSocial = await generoSocialModel.Incluir(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialController Inclusao [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            if (generoSocial.Erro || !generoSocial.Validacao) {
                return View("Form", generoSocial);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alteracao(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel(httpContext);

                generoSocial = await generoSocialModel.Alterar(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialController Alteracao [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

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
                generoSocialModel = new GeneroSocialModel(httpContext);

                generoSocial = await generoSocialModel.Excluir(id);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialController Exclusao [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            ViewData["Usuario"] = UsuarioNome;

            if (generoSocial.Erro || !generoSocial.Validacao) {
                return View("Form", generoSocial);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
