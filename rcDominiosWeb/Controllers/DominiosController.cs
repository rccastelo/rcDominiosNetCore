using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rcDominiosTransfers;
using rcDominiosWeb.Models;

namespace rcDominiosWeb.Controllers
{
    public class DominiosController : Controller
    {
        private readonly IHttpContextAccessor httpContext;

        public DominiosController(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
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
                autentica.IncluirErroMensagem("Erro em AutenticaController Consulta [" + ex.Message + "]");
            } finally {
                autenticaModel = null;
            }

            if (autentica.Erro || !autentica.Validacao) {
                return View("Index", autentica);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Lista()
        {
            AutenticaModel autenticaModel;

            autenticaModel = new AutenticaModel(httpContext);

            string token = autenticaModel.ObterToken();

            return View();
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
