using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rcDominiosTransfers;
using rcDominiosWeb.Models;

namespace rcDominiosWeb.Controllers
{
    public class DominiosController : ControllerDominios
    {
        public DominiosController(IHttpContextAccessor accessor)
            :base(accessor)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(AutenticaTransfer autenticaTransfer)
        {
            AutenticaModel autenticaModel;
            AutenticaTransfer autentica;

            try {
                autenticaModel = new AutenticaModel(httpContext);

                autentica = await autenticaModel.Autenticar(autenticaTransfer);
            } catch (Exception ex) {
                autentica = new AutenticaTransfer();

                autentica.Validacao = false;
                autentica.Erro = true;
                autentica.IncluirMensagem("Erro em AutenticaController Consulta [" + ex.Message + "]");
            } finally {
                autenticaModel = null;
            }

            if (autentica.Erro || !autentica.Validacao || !autentica.Autenticado) {
                return View("Index", autentica);
            } else {
                ViewData["Usuario"] = UsuarioNome;
                
                return RedirectToAction("Lista");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Lista()
        {
            AutenticaModel autenticaModel;
            string token = "";

            try {
                autenticaModel = new AutenticaModel(httpContext);

                token = autenticaModel.ObterToken();
            } catch {
                token = "";
            } finally {
                autenticaModel = null;
            }

            if (string.IsNullOrEmpty(token)) {
                return RedirectToAction("Sair");
            } else {
                ViewData["Usuario"] = UsuarioNome;

                return View();
            }
        }

        [HttpGet]
        public IActionResult Sair()
        {
            AutenticaModel autenticaModel;

            autenticaModel = new AutenticaModel(httpContext);

            autenticaModel.Sair();

            return RedirectToAction("Index");
        }
    }
}
