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
    public class PessoaTipoController : Controller
    {
        private readonly IHttpContextAccessor httpContext;

        public PessoaTipoController(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        [HttpGet]
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
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoModel = new PessoaTipoModel(httpContext);

                if (id > 0) {
                    pessoaTipo = await pessoaTipoModel.ConsultarPorId(id);
                } else {
                    pessoaTipo = null;
                }
            } catch {
                pessoaTipo = new PessoaTipoTransfer();
                
                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoController Form");
            } finally {
                pessoaTipoModel = null;
            }

            return View(pessoaTipo);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipoLista;

            try {
                pessoaTipoModel = new PessoaTipoModel(httpContext);

                pessoaTipoLista = await pessoaTipoModel.Consultar(new PessoaTipoTransfer());
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirMensagem("Erro em PessoaTipoController Lista [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            return View(pessoaTipoLista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consulta(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipoLista;

            try {
                pessoaTipoModel = new PessoaTipoModel(httpContext);

                pessoaTipoLista = await pessoaTipoModel.Consultar(pessoaTipoTransfer);
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirMensagem("Erro em PessoaTipoController Consulta [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoLista.Erro || !pessoaTipoLista.Validacao) {
                return View("Filtro", pessoaTipoLista);
            } else {
                return View("Lista", pessoaTipoLista);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inclusao(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoModel = new PessoaTipoModel(httpContext);

                pessoaTipo = await pessoaTipoModel.Incluir(pessoaTipoTransfer);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoController Inclusao [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return View("Form", pessoaTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alteracao(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoModel = new PessoaTipoModel(httpContext);

                pessoaTipo = await pessoaTipoModel.Alterar(pessoaTipoTransfer);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoController Alteracao [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return View("Form", pessoaTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoModel = new PessoaTipoModel(httpContext);

                pessoaTipo = await pessoaTipoModel.Excluir(id);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoController Exclusao [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return View("Form", pessoaTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
